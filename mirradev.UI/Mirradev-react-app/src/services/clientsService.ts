import axios from "axios";

export interface Client {
    id: string;
    name: string;
    email: string;
    balanceToken: string;
}

export async function getUsers(): Promise<Client[]> {
    try {
        const token = localStorage.getItem("token");
        const response = await axios.get<Client[]>("http://localhost:5108/clients", {
            headers: {
                Authorization: token
            }
        });
        return response.data;
    } catch (error) {
        console.error("Failed to fetch clients:", error);
        return [];
    }
}
