import React, { useEffect, useState } from "react"
import img from "../../assets/user.png"
import ButtonDropdown from "../../componentes/ButtonDropdown";
import Table from "../../componentes/Table";
import { obterClientes, Remover } from "../../Services/ServiceCliente";
import Cliente from "../../Interfaces/Cliente";
import { Link, useNavigate } from "react-router-dom";
import { obterStatus } from "../../Helpers/Utilitarios";
import openNotification from "../../componentes/Notificacao";

const ClientePage = () => {
    const [clientes, setCliente] = useState<Cliente[]>();

    const navigate = useNavigate();

    async function buscarClientes() {
        setCliente(await obterClientes())
    }

    function selecionarEdicao(id: number) {
        navigate(`/Cliente/Edicao/${id}`);
    }

    async function selecionarExcluir(id: number) {
        const result = await Remover(id)

        if (result.sucess) {
            await buscarClientes()
            openNotification("success", "Atenção", result.message!)
            return;
        }
        openNotification("error", "Atenção", result.message!)
    }

    useEffect(() => {
        buscarClientes()
    }, [])


    return (
        <div className="container">
            <div className="col-12">
                <div className="card mb-4">
                    <div className="row p-3">
                        <div className="col-2">
                            <div className="pb-0 ">
                                <h5>Clientes</h5>
                            </div>
                        </div>
                        <div className="col-10 d-flex bd-highlight">
                            <div className="ms-auto bd-highlight">
                                <Link className="btn btn-primary align-content-end" to="/Cliente/Cadastro">
                                    Adicionar Cliente
                                </Link>
                            </div>
                        </div>
                    </div>
                    <div className="card-body px-0 pt-0 pb-2">
                        <div className="table-responsive-sm">
                            <Table colunas={["Nome", "Endereco", "Status"]} classeTR=""
                                childrem={
                                    clientes?.map(cliente => {
                                        return (
                                            <tr key={cliente.id}>
                                                <td>
                                                    <div className="d-flex px-2 py-1">
                                                        <div>
                                                            <img src={img}
                                                                className="avatar avatar-sm me-3" alt="user1" />
                                                        </div>
                                                        <div className="d-flex flex-column justify-content-center">
                                                            <h6 className="mb-0 text-sm">{cliente.nome}</h6>
                                                            <p className="text-xs text-secondary mb-0">{cliente.nome}</p>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td>
                                                    <p className="text-xs text-secondary mb-0"><strong>Rua:</strong> {cliente.endereco.rua}</p>
                                                    <p className="text-xs text-secondary mb-0"><strong>Bairro:</strong> {cliente.endereco.bairro}</p>
                                                    <p className="text-xs text-secondary mb-0"><strong>Estado:</strong> {cliente.endereco.estado} </p>
                                                    <p className="text-xs text-secondary mb-0"><strong>CEP: </strong> {cliente.endereco.cep}</p>
                                                    <p className="text-xs text-secondary mb-0"><strong>Cidade: </strong> {cliente.endereco.cidade}</p>
                                                    <p className="text-xs text-secondary mb-0"><strong>Complemento:</strong> {cliente.endereco.complemento}</p>

                                                </td>
                                                <td className="align-middle text-sm">
                                                {cliente.clienteStatus === 1 ?
                                                     <span className="badge bg-success">{obterStatus(1)}</span> 
                                                   : <span className="badge bg-secondary">{obterStatus(cliente.clienteStatus)}</span>}
                                                </td>
                                                <td className="align-middle">
                                                    <ButtonDropdown
                                                        Campos={[
                                                            { classIcon: "bi bi-sliders", nome: "Editar", aoCliclar: () => { selecionarEdicao(cliente.id!) } },
                                                            { classIcon: "bi bi-x-square", nome: "Excluir", aoCliclar: () => selecionarExcluir(cliente.id!) }
                                                        ]}
                                                        nome="Ações" />
                                                </td>
                                            </tr>
                                        )
                                    })
                                }
                            />
                            {(clientes && clientes.length > 0) ||
                             <div className="alert alert-warning text-center" role="alert">
                              <span>  Nenhum Resultado encontrado</span>
                            </div>}
                        </div>
                    </div>
                </div>
            </div>

        </div>
    )
}

export default ClientePage;


