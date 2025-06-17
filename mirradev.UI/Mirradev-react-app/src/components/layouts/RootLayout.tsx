import { NavLink, Outlet } from "react-router-dom";
import Header from "./Header";

const RootLayout = () => {
    return (
        <div className="flex flex-row h-screen">
            <nav className="flex flex-col h-screen w-54 bg-blue-300">
                <h1 className="text-center border-b font-bold text-xl pt-3 h-14 bg-blue-500 text-white border-black">
                    Admin panel
                </h1>
                <NavLink
                    to={"/"}
                    className={"px-4 py-4 hover:bg-blue-400 duration-150 text-white font-bold text-lg"}>
                    Dashboard
                </NavLink>
                <NavLink
                    to={"/Payments"}
                    className={"px-4 py-4 hover:bg-blue-400 duration-150 text-white font-bold text-lg"}>
                    Payments
                </NavLink>
            </nav>
            <div className="flex-1 flex flex-col">
                <Header />
                <main className="flex-1">
                    <Outlet />
                </main>
            </div>
        </div>
    )
};

export default RootLayout;