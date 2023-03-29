import { useNavigate } from "react-router-dom"
import Login from "../../Interfaces/login"
import Result from "../../Interfaces/result"
import axios from "axios";

export async function LogarUsuario(login: Login): Promise<Result> {
    const apiLogin = axios.create({
        baseURL: "https://localhost:7215/API",
        // baseURL: "http://172.28.160.1:70/Api",
    })
    try {
        const response = await apiLogin.post("/Login/LogarUsuario", login);

        localStorage.setItem("email", login.email);
        localStorage.setItem("token", response.data.token);
        localStorage.setItem("expiracao", response.data.expiracao);
        
        return { sucess: true }
    } catch (erro) {
        return {
            sucess: false,
            message: "Falha ao logar"
        }
    }
}





export function deslogarUsuario() {

}
