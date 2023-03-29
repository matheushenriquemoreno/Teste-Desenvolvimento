import { item } from "../componentes/listaSuspensa";

const status: item[] = [{ id: 1, value: "Ativo" }, { id: 2, value: "Inativo" }, { id: 3, value: "Em Desenvolvimento" }]

export function obterStatusPlataforma(): item[] {
    return status
}

export function obterStatus(idEnumerador: number): string {
    return status.find(x => x.id === idEnumerador)?.value!
}

export function formatarPreco(valor: number) :  string{
    return valor.toLocaleString('pt-br', { style: 'currency', currency: 'BRL' })
}