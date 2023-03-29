import React, { FormEvent, useEffect, useState } from "react"
import { Link, MemoryRouter, useNavigate, useParams } from "react-router-dom";
import ListaSuspensa from "../../componentes/listaSuspensa";
import { ValidaFormularioVazio } from "../../Helpers/BoostrapHelpers";
import Produto from "../../Interfaces/Produto";
import Result from "../../Interfaces/result";
import { Atualizar, Cadastrar, obterProduto } from "../../Services/ProdutoService";
import { obterStatusPlataforma } from "../../Helpers/Utilitarios";


const CadastroProdutoPage = () => {
    const [nomeProduto, setProduto] = useState<string>("");
    const [descricao, setDescricao] = useState<string>("");
    const [valor, setValor] = useState<number>();
    const [quatidade, setQuantidade] = useState<number>();
    const [status, setStatus] = useState<number>(0);
    const [edicao, setEdicao] = useState<boolean>(false);


    const navigate = useNavigate();

    const { Id } = useParams();

    async function handdlerSubmit(e: FormEvent<HTMLFormElement>) {
        e.preventDefault();
        if (ValidaFormularioVazio()) {
            const produto: Produto = {
                nomeProduto: nomeProduto,
                statusDoProduto: status,
                descricao: descricao,
                valor: valor!,
                quatidade: quatidade!,
            }

            let result: Result = {}

            if (edicao) {
                produto.id = parseInt(Id!)
                result = await Atualizar(produto)
            }
            else {
               result = await Cadastrar(produto)
            }

            if(result.sucess){
                navigate("/Produtos")
            }else{
                alert(result.message!)
            }
        }
    }

    async function editarProduto() {
        const produto = await obterProduto(parseInt(Id!))
        setProduto(produto.nomeProduto)
        setDescricao(produto.descricao)
        setValor(produto.valor)
        setQuantidade(produto.quatidade)
        setStatus(produto.statusDoProduto)
        setEdicao(true);
    }

    useEffect(() => {
        if (Id) {
            editarProduto()
        }
    }, [])


    return (
        <div className="container">
            <div className="row justify-content-md-center">
                <div className="col-lg-8 col-sm-12 bg-light p-4 rounded-3">
                    <form className=" needs-validation " onSubmit={handdlerSubmit} noValidate>
                        <h5>{edicao ? "Editar produto" : "Cadastro de Produto"}</h5>
                        <div className="mt-3">
                            <div className="mb-3 text-dark">
                                <label className="form-label" >Nome Produto</label>
                                <input asp-for="Nome" type="text" className="form-control" maxLength={50} value={nomeProduto} onChange={(e) => setProduto(e.target.value)} id="" required />

                                <div className="invalid-feedback">Campo Obrigatorio</div>
                            </div>

                            <div className="mb-3 text-dark">
                                <label className="form-label">Descrição</label>
                                <textarea asp-for="Descricao" className="form-control" id="" value={descricao} onChange={(e) => setDescricao(e.target.value)} maxLength={100} rows={2} minLength={5} required> </textarea>
                                <div className="invalid-feedback">Campo Obrigatorio</div>
                            </div>

                            <div className="mb-3 text-dark">
                                <label className="form-label" >Valor Unitario</label>
                                <input asp-for="Nome" type="number" value={valor} min={0} step="0.01" className="form-control" id="" onChange={(e) => setValor(parseFloat(e.target.value))} required />

                                <div className="invalid-feedback">Digite um valor valido</div>
                            </div>

                            <div className="mb-3 text-dark">
                                <label className="form-label" >Quantidade</label>
                                <input asp-for="Nome" type="number" min={0} max={9999} value={quatidade} className="form-control" id="" onChange={(e) => setQuantidade(parseInt(e.target.value))} required />

                                <div className="invalid-feedback">Campo Obrigatorio</div>
                            </div>

                            <ListaSuspensa itens={obterStatusPlataforma()} aoAlterado={(value) => setStatus(value)} valor={status} label="Status" />

                            <div className="d-grid gap-2 d-md-flex justify-content-md-end mt-3">
                                <Link className="btn btn-secondary " to="/Produtos">
                                    Cancelar
                                </Link>
                                <button type="submit" className="btn btn-primary">{edicao ? "Editar" : "Cadastrar"}</button>
                            </div>
                        </div>

                    </form>
                </div>
            </div>

   
        </div>
    )

}

export default CadastroProdutoPage;