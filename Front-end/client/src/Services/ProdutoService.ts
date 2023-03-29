import { AxiosError } from "axios";
import { item } from "../componentes/listaSuspensa";
import Produto from "../Interfaces/Produto";
import Result from "../Interfaces/result";
import instaciarAxios from "./Apis/api";

export async function obterProdutos(): Promise<Produto[]> {

    const api = instaciarAxios();

    const result = await api.get<Array<Produto>>("/Produtos");

    const dados = result.data

    return dados;
}

export async function obterProdutosAtivos(): Promise<Produto[]> {

    const api = instaciarAxios();

    const result = await api.get<Array<Produto>>("/Produtos/Ativos");

    return result.data;
}

export async function obterProdutosSelectList(): Promise<item[]> {
    const dados = await obterProdutos()

    return dados.map(dado => {
        return {
            id: dado.id!,
            value: `${dado.nomeProduto} - ${dado.valor.toLocaleString('pt-br',{style: 'currency', currency: 'BRL'})}`
        }
    })
}

export async function obterProduto(id: number): Promise<Produto> {
    const api = instaciarAxios();

    const result = await api.get<Produto>(`/Produtos/${id}`);

    return result.data;
}

export async function Cadastrar(produto: Produto): Promise<Result> {

    const api = instaciarAxios()
    try {
        await api.post("/Produtos", produto)
        return { sucess: true , message: "Produto Cadastrado com sucesso!" };
    } catch (error: AxiosError | any) {
        return {
            message: error.response.data.message,
            sucess: false
        };
    }
}

export async function Atualizar(produto: Produto): Promise<Result> {
    const api = instaciarAxios()

    try {
        await api.put("/Produtos", produto)
        return { sucess: true , message: "Produto Atualizado com sucesso!" };
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
        await api.delete(`/Produtos/${id}`);
        return { sucess: true , message: "Produto Excluido com sucesso!" };
    } catch (error: AxiosError | any) {
        return {
            message: error.response?.data?.message ?? "Houve um Erro inesperado",
            sucess: false
        };
    }
}

