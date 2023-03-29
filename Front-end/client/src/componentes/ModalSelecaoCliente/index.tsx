import React, { useEffect, useState } from "react";
import { obterClientesSelectList } from "../../Services/ServiceCliente";
import ListaSuspensa, { item } from "../listaSuspensa";
import Modal from "../Modal";
import { MostrarModal, ValidaFormularioVazio } from "../../Helpers/BoostrapHelpers";


interface PropsModalCliente {
    idCliente: number,
    aoSelecionarCliente(id: number): void,
    aoSalvar(): void,
}

const ModalCliente = ({ aoSalvar, aoSelecionarCliente, idCliente }: PropsModalCliente) => {
    const [dadosCliente, setDadosCliente] = useState<item[]>([]);

    async function inicializarCamposBusca() {
        const dados = await obterClientesSelectList()
        setDadosCliente(dados)
    }

    function validarFormulario() {
        if (ValidaFormularioVazio()) {
            aoSalvar()
        }
    }

    useEffect(() => {
        inicializarCamposBusca()

    },[idCliente])

    return (
        <div>
            <Modal
                idModal={"modal-selecao-cliente"}
                aoSalvarModal={validarFormulario}
                tituloModal="Seleção de Cliente"
                children={
                    <form noValidate className="needs-validation" >
                        <div className="row">
                            <div className="col-12 mb-3">
                                <ListaSuspensa itens={dadosCliente!} aoAlterado={(value) => aoSelecionarCliente(value)} valor={idCliente} label="Cliente" />
                            </div>
                        </div>
                    </form>
                } />
        </div>
    )
}


export default ModalCliente