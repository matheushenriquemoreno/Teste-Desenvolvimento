import { AxiosError, AxiosResponse } from "axios";
import Cliente from "../Interfaces/Cliente";
import instaciarAxios from "./Apis/api";
import {item} from "../componentes/listaSuspensa"
import Result from "../Interfaces/result";

export async function obterClientes(): Promise<Cliente[]> {

    const api = instaciarAxios();

    const result = await api.get<Array<Cliente>>("/Clientes");

    const dados = result.data

    return dados;
}

export async function obterClientesSelectList() : Promise<item[]>{
    const dados = await obterClientes()
    
    return dados.map(dado =>  {
        return{
            id: dado.id!,
            value: `${dado.id} - ${dado.nome} ` 
        }
    })
}

export async function obterCliente(id:number) : Promise<Cliente> {
    const api = instaciarAxios();
    
    const result: AxiosResponse = await api.get<Cliente>(`/Clientes/${id}`);

    return result.data;
}

export async function Cadastrar(produto: Cliente): Promise<Result> {
    const api = instaciarAxios()

    try {
         await api.post("/Clientes", produto)
         return { sucess: true , message: "Cliente Cadastrado com sucesso!" };
    } catch (error: AxiosError | any) {
        return {
            message: error.response.data.message,
            sucess: false
        };
    }
}

export async function Atualizar(produto: Cliente): Promise<Result> {

    const api = instaciarAxios()
    try {
         await api.put("/Clientes", produto)
        return { sucess: true , message: "Cliente Atualizado com sucesso!" };
    } catch (error: AxiosError | any) {
        return {
            message: error.response?.data?.message ?? "Houve um Erro inesperado",
            sucess: false
        };
    }
}

export async function Remover(id: number): Promise<Result> {
    const api = instaciarAxios();
    try {
        await api.delete(`/Clientes/${id}`);
        return { sucess: true , message: "Cliente Excluido com sucesso!" };
    } catch (error: AxiosError | any) {
        return {
            message: error.response?.data?.message ?? "Houve um Erro inesperado",
            sucess: false
        };
    }
}
