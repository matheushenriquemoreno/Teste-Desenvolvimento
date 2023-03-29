import { AxiosError } from "axios";
import { DadosPedidos, PedidoCreate } from "../Interfaces/Pedido";
import Result from "../Interfaces/result";
import instaciarAxios from "./Apis/api";

export default class servicoPedido {

    static async fazerPedido(pedido: PedidoCreate): Promise<Result>{
        const api = instaciarAxios()
        try {
            await api.post("/Pedidos/FazerPedido", pedido)
            return {message: "Pedido Criado com sucesso", sucess: true };
        } catch (error: AxiosError | any) {
            return {
                message: error.response.data.message,
                sucess: false
            };
        }
    }

    static  async obterPedidos(): Promise<DadosPedidos[]>{
        const api = instaciarAxios();

        const result = await api.get<Array<DadosPedidos>>("/Pedidos");
    
        return result.data
    }
    
}

