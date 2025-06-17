import { useEffect, useState } from "react";
import { getUsers, type Client } from "../services/clientsService";
import { getCurrentTokenRate, updateTokenRate } from "../services/tokenRatesService";

const Dashboard = () => {
    const [clients, setClients] = useState<Client[]>();
    const [showUpdateTokenModal, setShowUpdateTokenModal] = useState(false);
    const [tokenRate, setTokenRate] = useState("");
    const [updateToken, setUpdateToken] = useState("");

    useEffect(() => {
        const fetchClients = async () => {
            const users = await getUsers();
            setClients(users);
        };

        fetchClients();
    }, []);

    useEffect(() => {
        const fetchTokenRate = async () => {
            const tokenRate = await getCurrentTokenRate();
            setTokenRate(tokenRate);
        };

        fetchTokenRate();
    });

    const handleClickUpdateButton = () => {
        setUpdateToken("")
        setShowUpdateTokenModal(!showUpdateTokenModal);
    };

    const handleSaveTokenRateButton = async () => {
        const response = await updateTokenRate(updateToken);
        setUpdateToken(response);
        setShowUpdateTokenModal(!showUpdateTokenModal);
    }

    return (
        <div className="overflow-x-auto mt-4 p-4 relative">
            {showUpdateTokenModal && (
                <div className="fixed inset-0 flex justify-center items-center bg-opacity-50 z-50">
            <div className="bg-white p-6 rounded-lg shadow-lg w-[300px] h-auto">
                <h2 className="text-lg font-semibold mb-4 text-center">Update Token</h2>
                <input
                    type="number"
                    value={updateToken}
                    onChange={(e) => setUpdateToken(e.target.value)}
                    placeholder="Enter new value"
                    className="w-full bg-gray-100 px-4 py-1 rounded-md" />

                <div className="flex flex-row gap-2 items-center justify-center mt-6">
                    <button 
                        className="bg-blue-400 px-6 py-2 rounded-md text-white font-bold cursor-pointer"
                        onClick={handleSaveTokenRateButton}>
                        Save
                    </button>
                    <button 
                        className="bg-red-400 px-6 py-2 rounded-md text-white font-bold cursor-pointer"
                        onClick={handleClickUpdateButton}>
                        Close
                    </button>
                </div>
            </div>
        </div>
            )}
            <div className="flex flex-row gap-4 items-center">
                <h1 className="border-b text-2xl font-bold">Token Rate value: {tokenRate}</h1>
                <button
                    className="bg-blue-400 px-4 py-1 rounded-md text-white shadow-md cursor-pointer"
                    onClick={handleClickUpdateButton}>
                    Update
                </button>
            </div>
            <h1 className="mt-10 text-4xl font-bold mb-4">Clients</h1>
            <table className="min-w-full border border-blue-200">
                <thead className="bg-blue-100">
                    <tr>
                        <th className="px-4 py-2 text-left border-2 border-blue-300">Name</th>
                        <th className="px-4 py-2 text-left border-2 border-blue-300">Email</th>
                        <th className="px-4 py-2 text-left border-2 border-blue-300">Balance (T)</th>
                    </tr>
                </thead>
                <tbody>
                    {clients?.map((client) => (
                        <tr className="hover:bg-gray-50" key={client.id}>
                            <td className="px-4 py-2 border-2 border-blue-300">{client.name}</td>
                            <td className="px-4 py-2 border-2 border-blue-300">{client.email}</td>
                            <td className="px-4 py-2 border-2 border-blue-300">{client.balanceToken}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
};

export default Dashboard;