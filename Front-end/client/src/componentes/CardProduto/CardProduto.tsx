import React from "react";
import Produto from "../../Interfaces/Produto";

interface PropsCarProduto {
    Produto: Produto,
    acaoAoComprar(idProduto: number): void
}

const CardProduto = ({ Produto, acaoAoComprar }: PropsCarProduto) => {

    return (
        <div className="col" key={Produto.id}>
            <div className="card  shadow-sm">
                <img
                    src="https://www.freepnglogos.com/uploads/box-png/closed-square-cardboard-box-transparent-png-svg-vector-35.png"
                    className="card-img-top" alt="..." />
                <div className="card-body">
                    <div className="clearfix mb-3">
                        <span className="float-start badge rounded-pill bg-success">{Produto.valor.toLocaleString('pt-br', { style: 'currency', currency: 'BRL' })}</span>
                        <span className="float-end badge rounded-pill bg-primary">Estoque: {Produto.quatidade}</span>
                    </div>
                    <h5 >
                        {Produto.nomeProduto}
                    </h5>
                    <strong className="text-xs text-secondary">Descricao: </strong>
                    <p className="">
                        {Produto.descricao}
                    </p>

                    <div className="d-grid gap-2 my-4">
                        <button className="btn btn-warning" onClick={() => acaoAoComprar(Produto.id!)}>Comprar
                        </button>
                    </div>
                </div>
            </div>
        </div>
    )
}



export default CardProduto;