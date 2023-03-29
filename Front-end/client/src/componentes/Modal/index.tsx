import React from "react";

export interface PropsModal{
    idModal: string,
    tituloModal: string,
    children: React.ReactNode,
    aoSalvarModal?(): void,
    aoFecharModal?(): void,
    mostrarBotaoConfirmar?: boolean,
    tamanho?: string
}

const Modal = ({idModal, tituloModal, children, aoSalvarModal, aoFecharModal , mostrarBotaoConfirmar = true, tamanho = ""}: PropsModal) => {
    return (
        <div className={"modal fade " + tamanho} id={idModal}  aria-hidden="true">
            <div className="modal-dialog">
                <div className="modal-content">
                    <div className="modal-header">
                        <h1 className="modal-title fs-5">{tituloModal}</h1>
                        <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close" onClick={aoFecharModal}></button>
                    </div>
                    <div className="modal-body">
                    {children}
                    </div>
                    <div className="modal-footer">
                        <button type="button" className="btn btn-secondary" data-bs-dismiss="modal" onClick={aoFecharModal}>Fechar</button>
                        {
                            mostrarBotaoConfirmar && <button type="button" className="btn btn-primary" onClick={aoSalvarModal}>Continuar</button>
                        }
                    </div>
                </div>
            </div>
        </div>
    )
}


export default Modal;