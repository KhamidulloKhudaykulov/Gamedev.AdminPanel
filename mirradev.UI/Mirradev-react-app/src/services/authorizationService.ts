import axios from "axios";

export async function auth(login: string, password: string) {
    try {
        const response = await axios.post("http://localhost:5108/auth", null, {
            params: {
                login: login,
                password: password,
            },
        });

        return response.data;
    } catch (error) {
        console.error("Login failed:", error);
        throw error;
    }
}
