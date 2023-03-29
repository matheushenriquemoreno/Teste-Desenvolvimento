export default interface Produto {
    id?: number,
    nomeProduto: string,
    descricao: string,
    valor: number,
    quatidade: number,
    statusDoProduto: number,
    statusString?:string
}


export interface ItemCarrinho{
    idProduto: number,
    quantidadeItens: number,
    Produto: Produto
}


