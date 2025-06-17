import { useEffect, useState } from "react";
import { getPayments } from "../services/paymentsService";
import { type Payment } from "../services/paymentsService";
import { useNavigate } from "react-router-dom";

const Payments = () => {
    const [payments, setPayments] = useState<Payment[]>([]);

    const navigate = useNavigate();

    useEffect(() => {
        const fetchTokenRate = async () => {
            const token = localStorage.getItem("token");
            if (token == "" || token == null){
                navigate("/login");
            }
            const response = await getPayments();
            setPayments(response);
        };

        fetchTokenRate();
    }, [])
    return (
        <div className="flex flex-col p-4">
            <h1 className="text-3xl font-bold mb-6">Payments history</h1>
            <table className="min-w-full border border-blue-200">
                <thead className="bg-blue-100">
                    <tr>
                        <th className="px-4 py-2 text-left border-2 border-blue-300">Client id</th>
                        <th className="px-4 py-2 text-left border-2 border-blue-300">Amount</th>
                        <th className="px-4 py-2 text-left border-2 border-blue-300">Date</th>
                    </tr>
                </thead>
                <tbody>
                    {payments.map((payment) => (
                        <tr className="hover:bg-gray-50" key={payment.id}>
                            <td className="px-4 py-2 border-2 border-blue-300">{payment.clientId}</td>
                            <td className="px-4 py-2 border-2 border-blue-300">{payment.amount}</td>
                            <td className="px-4 py-2 border-2 border-blue-300">{payment.createdAt}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    )
};

export default Payments;