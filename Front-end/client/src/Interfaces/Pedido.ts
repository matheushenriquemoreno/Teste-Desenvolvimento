import Produto, { ItemCarrinho } from "./Produto";
import Cliente from "./Cliente";
import Endereco from "./Endereco";

export interface PedidoCreate{
    idCliente: number,
    produtos: ItemCarrinho[]
}

export interface ItemPedido {
    id: number,
    produto: Produto,
    valor: number,
    quantidade: number, 
}

export interface DadosPedidos{
    id: number,
    produtos: ItemPedido[],
    cliente: Cliente,
    quantidade: number,
    valorTotal: number,
    enderecoEntrega: Endereco
}
