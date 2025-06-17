import { BrowserRouter, Route, Routes } from "react-router-dom"
import RootLayout from "./components/layouts/RootLayout"
import Dashboard from "./components/Dashboard"
import Payments from "./components/Payments"
import Login from "./components/authorization/Login"

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/login" element={<Login />} />
        <Route element={<RootLayout />}>
          <Route path="/" element={<Dashboard />} />
          <Route path="/payments" element={<Payments />} />
        </Route>
      </Routes>
    </BrowserRouter>
  )
}

export default App
