import axios from "axios";

export interface Payment {
    id: string;
    amount: number;
    clientId: string;
    createdAt: string;
}

export async function getPayments(): Promise<Payment[]> {
    try {
        const token = localStorage.getItem("token");
        const response = await axios.get<Payment[]>("http://localhost:5108/payments?amount=5", {
            headers: {
                Authorization: token
            }
        })
        return response.data;
    } catch (error) {
        console.error("Failed to fetch clients:", error);
        return [];
    }
};
