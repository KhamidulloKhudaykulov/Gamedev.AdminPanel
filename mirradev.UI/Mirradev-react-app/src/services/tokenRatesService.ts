import axios from "axios";

export async function getCurrentTokenRate(): Promise<string> {
    try {
        const token = localStorage.getItem("token");
        const response = await axios.get("http://localhost:5108/rate", {
            headers: {
                Authorization: token
            }
        });
        return response.data;
    } catch (error) {
        throw new Error("Something went wrong");
    }
};

export async function updateTokenRate(value: string) {
    try {
        const token = localStorage.getItem("token");
        const response = await axios.post("http://localhost:5108/rate", null, {
            params: {
                value: value
            },
            headers: {
                Authorization: token
            }
        });

        return response.data;
    } catch (error) {
        throw new Error("Something went wrong");
    }
}