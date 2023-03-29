import React, { useEffect, useState } from "react"
import "./teste.css"
import { DadosPedidos } from "../../Interfaces/Pedido";
import servicoPedido from "../../Services/PedidoService";
import { Divider, List } from 'antd';


const PedidosPage = () => {
    const [pedidos, setPedido] = useState<DadosPedidos[]>([])

    async function buscarPedidos() {
        setPedido(await servicoPedido.obterPedidos())
    }

    useEffect(() => {
        buscarPedidos()
    }, [])

    return (
        <div className="container">
            <div className="row">
                <div className="col-md-12 mt-4 ">
                    <div className="card mb-5">
                        <div className="row p-3">
                            <div className="col-5">
                                <div >
                                    <h5>Pedidos</h5>
                                </div>
                            </div>
                        </div>

                        <div className="card-body">
                            {(!pedidos || pedidos.length <= 0) ?
                                <div className="alert alert-warning text-center" role="alert">
                                    Nenhum Resultado encontrado
                                </div>
                                :
                                <List itemLayout="horizontal"
                                    dataSource={pedidos}
                                    size="large"
                                    pagination={{
                                        position: "bottom",
                                        align: "center",
                                        pageSize: 2,
                                    }}
                                    renderItem={(pedido, index) => (
                                        <li className="bg-black bg-opacity-10 rounded mt-2">
                                            <div className="row p-4 mb-2">
                                                {/*Dados cliente*/}
                                                <div className="col-md-6 d-flex flex-column text-sm mb-3">
                                                    <h6 className="mb-3 ">Cliente: {pedido.cliente.nome}</h6>

                                                    <span className="mb-2">Nome:
                                                        <span className="text-dark ms-sm-2 font-weight-bold">
                                                            {pedido.cliente.nome}
                                                        </span>
                                                    </span>
                                                    <span className="mb-2">Entrega:
                                                        <span className="text-dark ms-sm-2 font-weight-bold">
                                                            {pedido.enderecoEntrega.rua}, {pedido.enderecoEntrega.bairro}, {pedido.enderecoEntrega.cidade}, {pedido.enderecoEntrega.estado}, {pedido.enderecoEntrega.complemento}
                                                        </span>
                                                    </span>

                                                    <span className="">CEP:
                                                        <span className="text-dark ms-sm-2 font-weight-bold">
                                                            {pedido.enderecoEntrega.cep}
                                                        </span>
                                                    </span>
                                                </div>

                                                {/*Dados Pedido*/}
                                                <div className="col-md-6 d-flex flex-column text-sm">
                                                    <h6 className="mb-3 ">Informações do pedido</h6>
                                                    <span className="mb-2 ">Quantidade de itens:
                                                        <span className="text-success ms-sm-2 font-weight-bold">
                                                            {pedido.produtos.length}
                                                        </span>
                                                    </span>

                                                    <span className="mb-2 ">Valor total:
                                                        <span className="text-success ms-sm-2 font-weight-bold">
                                                            {pedido.valorTotal.toLocaleString('pt-br', { style: 'currency', currency: 'BRL' })}
                                                        </span>
                                                    </span>
                                                </div>

                                              
                                                {/*Dados Produto*/}
                                                <Divider>Produtos</Divider>
                                                {pedido.produtos.map((produto, index) => {
                                                    return (
                                                        <div className="col-md-3 d-flex flex-column text-sm mb-3">
                                                            <h6 className="mb-3  ">item {index + 1}</h6>

                                                            <span className="mb-2 ">Nome:
                                                                <span className="text-dark ms-sm-2 font-weight-bold">
                                                                    {produto.produto.nomeProduto}
                                                                </span>
                                                            </span>

                                                            <span className="mb-2 ">Valor Pago:
                                                                <span className="ms-sm-2 text-success">
                                                                    {produto.valor.toLocaleString('pt-br', { style: 'currency', currency: 'BRL' })}
                                                                </span>
                                                            </span>
                                                            <span className="mb-2 ">Quantidade de itens:
                                                                <span className="text-dark ms-sm-2 font-weight-bold">
                                                                    {produto.quantidade}
                                                                </span>
                                                            </span>
                                                        </div>
                                                    )
                                                })}
                                            </div>

                                        </li>
                                    )}

                                />

                            }

                        </div>
                    </div>
                </div>
            </div>

        </div>
    )

}

export default PedidosPage;

