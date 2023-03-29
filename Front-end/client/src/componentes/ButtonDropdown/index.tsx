
import React, { MouseEvent } from 'react';

interface campo {
    classIcon: string,
    nome: string,
    aoCliclar(): void
}

export interface PropsButton {
    nome: string,
    Campos: campo[]
}

const ButtonDropdown = ({ nome, Campos }: PropsButton) => {
    return (
        <div className="btn-group" key={nome}>
            <button type="button" className="btn btn-secondary dropdown-toggle" data-bs-toggle="dropdown" aria-expanded="false">
                {nome}
            </button>

            <ul className="dropdown-menu dropdown-menu-dark ">
                {Campos.map(campo => {
                    return (
                        <>
                            <li onClick={() => campo.aoCliclar()} key={campo.nome}>
                                <a className="dropdown-item d-flex gap-2 align-items-center" href="#">
                                    <i className={campo.classIcon}></i>
                                    {campo.nome}
                                </a>
                            </li>
                            <li key={campo.nome + "1"}><hr className="dropdown-divider" /></li>
                        </>
                    )
                })}
            </ul>
        </div>

    )
}


export default ButtonDropdown;