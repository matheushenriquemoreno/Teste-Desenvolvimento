import React, { useEffect, useState } from "react"
import { Link, useNavigate } from "react-router-dom";
import ButtonDropdown from "../../componentes/ButtonDropdown";
import Table from "../../componentes/Table";
import Produto from "../../Interfaces/Produto";
import { obterProdutos, Remover } from "../../Services/ProdutoService";
import { obterStatus, obterStatusPlataforma } from "../../Helpers/Utilitarios";
import openNotification from "../../componentes/Notificacao";


const ProdutosPage = () => {
    const [produtos, setProdutos] = useState<Produto[]>()

    const navigate = useNavigate();

    async function buscarProduto() {
        setProdutos(await obterProdutos())
    }

    function selecionarEdicao(id: number) {
        navigate(`/Produto/Edicao/${id}`);
    }

    async function selecionarExcluir(id: number) {
        const result = await Remover(id)

        if (result.sucess) {
            await buscarProduto()
            openNotification("success", "Atenção", result.message!)
            return;
        }

        openNotification("error", "Atenção", result.message!)
    }

    useEffect(() => {
        buscarProduto()
    }, [])

    return (
        <div className="container">
            <div className="col-12">
                <div className="card">
                    <div className="row p-3">
                        <div className="col-2">
                            <div className="pb-0">
                                <h5>Produtos</h5>
                            </div>
                        </div>
                        <div className="col-10 d-flex bd-highlight">
                            <div className="ms-auto bd-highlight">
                                <Link className="btn btn-primary align-content-end" to="/Produto/Cadastro">
                                    Cadastrar Produto
                                </Link>
                            </div>
                        </div>
                    </div>

                    <div className="card-body px-0 pt-0">
                        <div className="table-responsive-sm">
                            <Table colunas={["Nome", "Descricao", "Quantidade", "Valor Unitario", "Status"]} classeTR="text-center"
                                childrem={
                                    produtos?.map(produto => {
                                        return (
                                            <tr className="p-1 text-center" key={produto.id}>
                                                <td>
                                                    <div className="px-2 py-1">
                                                        <h6 className="mb-0 text-sm">{produto.nomeProduto}</h6>
                                                    </div>
                                                </td>

                                                <td>
                                                    <div className="px-2 py-1">
                                                        <h6 className="mb-0 text-sm">{produto.descricao}</h6>
                                                    </div>
                                                </td>
                                                <td className="align-middle">
                                                    <p className="text-xs font-weight-bold mb-0"><strong>{produto.quatidade}</strong></p>
                                                </td>
                                                <td className="align-middle">
                                                    <p className="text-xs font-weight-bold mb-0 text-success"><strong>{produto.valor.toLocaleString('pt-br',{style: 'currency', currency: 'BRL'})}</strong></p>
                                                </td>
                                                <td className="align-middle text-sm">
                                                    {produto.statusDoProduto === 1 ?
                                                     <span className="badge bg-success">{obterStatus(1)}</span> 
                                                   : <span className="badge bg-secondary">{obterStatus(produto.statusDoProduto)}</span>}
                                                </td>
                                                <td className="align-middle">
                                                    <ButtonDropdown
                                                        Campos={
                                                            [
                                                                { classIcon: "bi bi-sliders", nome: "Editar", aoCliclar: () => { selecionarEdicao(produto.id!) } },
                                                                { classIcon: "bi bi-x-square", nome: "Excluir", aoCliclar: () => { selecionarExcluir(produto.id!) } }
                                                            ]}
                                                        nome="Ações" />
                                                </td>
                                            </tr>
                                        )
                                    })
                                }
                            />
                        </div>

                        {(produtos && produtos.length > 0) ||
                            <div className="alert alert-warning text-center" role="alert">
                                Nenhum Resultado encontrado
                            </div>
                        }
                    </div>
                </div>
            </div>

        </div>
    )

}

export default ProdutosPage;