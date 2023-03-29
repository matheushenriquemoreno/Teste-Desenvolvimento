import Produto, { ItemCarrinho } from "../../Interfaces/Produto";
import { obterProdutosAtivos } from "../../Services/ProdutoService";
import CardProduto from "../../componentes/CardProduto/CardProduto";
import CarrinhoCompras from "../../componentes/CarinhoCompras/CarrinhoCompras";
import "./style.css";
import React, { useEffect, useState } from "react";
import { PedidoCreate } from "../../Interfaces/Pedido";
import ModalCliente from "../../componentes/ModalSelecaoCliente";
import { MostrarModal } from "../../Helpers/BoostrapHelpers";
import servicoPedido from "../../Services/PedidoService";
import { useNavigate } from "react-router-dom";
import openNotification from "../../componentes/Notificacao";


const Compra = () => {
    const [produtos, setProdutos] = useState<Produto[]>()
    const [itensCarrinho, setItensCarrinho] = useState<ItemCarrinho[]>([])
    const [idUsuarioCompra, setIdUsuarioCompra] = useState<number>(0)
    const navigate = useNavigate();

    async function listarProdutos() {
        setProdutos(await obterProdutosAtivos())
    }

    function removerProduto(idProduto: number) {
        const itens = itensCarrinho.filter(iten => iten.idProduto !== idProduto)

        setItensCarrinho(itens)
    }

    function aumentarQuantidade(idProduto: number) {
        const produtoSelecionado = produtos?.find(produto => produto.id === idProduto)

        if (itensCarrinho.find(produto => produto.idProduto === produtoSelecionado?.id && produtoSelecionado.quatidade === produto.quantidadeItens)) {
            openNotification("error","Quantidade maxima atingida!", "Não sera possivel adicionar mais itens.");
            return;
        }

        const itens = itensCarrinho?.map(produto => {
            if (produto.idProduto === produtoSelecionado?.id) {
                produto.quantidadeItens += 1;
            }
            return produto;
        })

        setItensCarrinho(itens)
    }

    function diminuirQuantidade(idProduto: number) {
        if (itensCarrinho.find(produto => produto.idProduto === idProduto && produto.quantidadeItens === 1)) {
            removerProduto(idProduto);
            return;
        }

        const itens = itensCarrinho?.map(produto => {
            if (produto.idProduto === idProduto) {
                produto.quantidadeItens -= 1;
            }

            return produto;
        })

        setItensCarrinho(itens)
    }

    function selecionarClienteParaPedido() {
        if (itensCarrinho.length <= 0) {
            openNotification("error","Atenção", "Somente podera efetuar um pedido apos seleção de produtos");
            return;
        }

        MostrarModal("modal-selecao-cliente")
    }

    async function efetuarSolicitacaoDeCompra() {
        const dadoPedido: PedidoCreate = {
            idCliente: idUsuarioCompra!,
            produtos: itensCarrinho
        }
        MostrarModal("modal-selecao-cliente", false)

        const result = await servicoPedido.fazerPedido(dadoPedido)

        if(result.sucess){
            openNotification("success","Atenção", "Pedido Efetuado com sucesso!", () => {
                navigate("/Pedidos")
            });
            setItensCarrinho([])
            setIdUsuarioCompra(0)
            return
        }

        openNotification("error","Atenção", result.message ?? "Houve um erro ao realizar o pedido");
    }

    function adicionarProdutoCarrinho(idProduto: number) {
        const produtoSelecionado = produtos?.find(produto => produto.id === idProduto)

        if (itensCarrinho.length == 0) {
            setItensCarrinho([{ idProduto: produtoSelecionado?.id!, quantidadeItens: 1, Produto: produtoSelecionado! }])
            return;
        }

        if (!itensCarrinho.find(produto => produto.idProduto === produtoSelecionado?.id)) {
            setItensCarrinho([...itensCarrinho!, { idProduto: produtoSelecionado?.id!, quantidadeItens: 1, Produto: produtoSelecionado! }])
            return;
        }

        aumentarQuantidade(idProduto)
    }

    useEffect(() => {
        listarProdutos()
    }, [])

    return (
        <div className="container personalizado mt-5">

            <div className="row p-3 bg-light mb-5 rounded-4">
                <div className="col-2">
                    <div className="pb-0">
                        <h5>Produtos</h5>
                    </div>
                </div>
                <div className="col-10 d-flex bd-highlight">
                    <CarrinhoCompras classCarrinho="ms-auto bd-highlight"
                        itensCarrinho={itensCarrinho}
                        aumentarQuantidadeItem={aumentarQuantidade}
                        excluirProduto={removerProduto}
                        diminuirQuantidade={diminuirQuantidade}
                        aoFinalizarCompra={selecionarClienteParaPedido}
                    />
                </div>
            </div>

            <div className="row row-cols-1 row-cols-xs-2 row-cols-sm-2 row-cols-lg-4 g-3 mb-5">
                {
                    produtos?.map(produto => {
                        return (
                            <CardProduto key={produto.id} Produto={produto} acaoAoComprar={(id) => adicionarProdutoCarrinho(id)} />
                        )
                    })
                }
            </div>

            <ModalCliente aoSalvar={efetuarSolicitacaoDeCompra} aoSelecionarCliente={setIdUsuarioCompra} idCliente={idUsuarioCompra} />
        </div>
    )
}



export default Compra;