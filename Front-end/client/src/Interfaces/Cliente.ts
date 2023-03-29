import Endereco from "./Endereco";

export default interface Cliente {
    id?: number,
    nome: string,
    clienteStatus: number,
    endereco: Endereco,
}


