import { useState } from "react";
import { auth } from "../../services/authorizationService";
import { useNavigate } from "react-router-dom";

const Login = () => {
    const [login, setLogin] = useState("");
    const [password, setPassword] = useState("");

    const navigate = useNavigate();

    const handleLogin = async () => {
        try {
            const data = await auth(login, password);
            localStorage.setItem("token", `Bearer ${data.token}`);
            navigate("/");
        }catch(error){
            alert(error);
        };
    };

    return (
        <div className="h-screen flex flex-col justify-center items-center">
            <div className="flex flex-col gap-8 w-120 h-auto bg-blue-100 shadow-xl rounded-2xl p-6">
                <div className="flex-1 flex flex-col gap-4">
                    <h1 className="text-center text-blue-500 text-2xl font-bold border-b pb-2 border-blue-300">Gamedev Admin</h1>
                    <input
                        type="text"
                        value={login}
                        onChange={(e) => setLogin(e.target.value)}
                        placeholder="Login"
                        className="w-full bg-white rounded-lg px-4 py-2 border-1 border-blue-300 focus:outline-none focus:ring-1 focus:ring-blue-400 hover:border-blue-400 duration-150" />

                    <input
                        type="password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        placeholder="Password"
                        className="w-full bg-white rounded-lg px-4 py-2 border-1 border-blue-300 focus:outline-none focus:ring-1 focus:ring-blue-400 hover:border-blue-400 duration-150" />
                </div>
                <div className="flex-1 flex justify-center items-center">
                    <button 
                        className="bg-blue-400 px-14 py-2 rounded-lg shadow-lg text-white hover:bg-blue-600 duration-150 hover:px-18 hover:font-bold cursor-pointer"
                        onClick={handleLogin}>
                        Sign in
                    </button>
                </div>
            </div>
        </div>
    )
};

export default Login;