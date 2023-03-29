import React, { FormEvent, useEffect, useState } from "react"
import { Link, useNavigate, useParams } from "react-router-dom";
import ListaSuspensa from "../../componentes/listaSuspensa";
import { ValidaFormularioVazio } from "../../Helpers/BoostrapHelpers";
import Cliente from "../../Interfaces/Cliente";
import { Atualizar, Cadastrar, obterCliente } from "../../Services/ServiceCliente";
import InputMask from "react-input-mask";
import Result from "../../Interfaces/result";
import { obterStatusPlataforma } from "../../Helpers/Utilitarios";

const CadastroClientePage = () => {
    const [nomeCliente, setCliente] = useState<string>("");
    const [bairro, setBairro] = useState<string>("");
    const [rua, setRua] = useState<string>("");
    const [cep, setCep] = useState<string>("");
    const [estado, setEstado] = useState<string>("");
    const [cidade, setCidade] = useState<string>("");
    const [complemento, setcomplemento] = useState<string>("");
    const [status, setStatus] = useState<number>(0);
    const [edicao, setEdicao] = useState<boolean>(false);
    const navigate = useNavigate();

    const { Id } = useParams();

    async function handlerSubmit(e: FormEvent<HTMLFormElement>) {
        e.preventDefault();
        if (ValidaFormularioVazio()) {
            const cliente: Cliente = {
                clienteStatus: status,
                nome: nomeCliente,
                endereco: {
                    
                    bairro: bairro,
                    rua: rua,
                    cep: cep.replace("-", ""),
                    cidade: cidade,
                    complemento: complemento,
                    estado: estado,
                },
            }

            let result: Result = {}

            if (edicao) {
                cliente.id = parseInt(Id!);
                result = await Atualizar(cliente)
            }
            else {
                result = await Cadastrar(cliente)
            }

            if(result.sucess){
                navigate("/Clientes")
            }else{
                alert(result.message!)
            }
        }
    }

    async function edicaoDeCliente() {
        const cliente = await obterCliente(parseInt(Id!));
        setCliente(cliente.nome);
        setBairro(cliente.endereco.bairro)
        setCep(cliente.endereco.cep)
        setEstado(cliente.endereco.estado)
        setCidade(cliente.endereco.cidade)
        setcomplemento(cliente.endereco.complemento)
        setStatus(cliente.clienteStatus)
        setRua(cliente.endereco.rua)
        setEdicao(true)
    }

    useEffect(() => {
        if (Id) {
            edicaoDeCliente()
        }
    }, [])

    return (
        <div className="container">
            <div className="row justify-content-md-center">
                <div className="col-lg-8 col-sm-12 bg-light p-4 rounded-3">
                    <form className="needs-validation" onSubmit={handlerSubmit} noValidate>
                        <h5>{edicao ? "Editar Cliente" : "Cadastro de Cliente"}</h5>
                        <div className="mt-3">
                            <div className="mb-3 text-dark">
                                <label className="form-label" >Nome Cliente</label>
                                <input asp-for="Nome" type="text" maxLength={50} className="form-control" value={nomeCliente} onChange={(e) => setCliente(e.target.value)} id="" required />

                                <div className="invalid-feedback">Campo Obrigatorio</div>
                            </div>

                            <ListaSuspensa itens={obterStatusPlataforma()} aoAlterado={(value) => setStatus(value)} valor={status} label="Status" />

                            <h5 className="mt-4">Endereco</h5>
                            <hr />
                            <div className="row">
                                <div className="mb-3 col-4 text-dark">
                                    <label className="form-label">CEP</label>
                                    <InputMask
                                        mask="99999-999"
                                        maskChar=""
                                        type={"text"}
                                        minLength={9}
                                        value={cep}
                                        onChange={(e) => setCep(e.target.value)}
                                        className="form-control"
                                        required={true}
                                    />
                                    <div className="invalid-feedback">Campo Obrigatorio</div>
                                </div>

                                <div className="mb-3 col-8 text-dark">
                                    <label className="form-label">Rua ou Avenida</label>
                                    <input asp-for="Nome" type="text" className="form-control" value={rua} onChange={(e) => setRua(e.target.value)} id="" required />
                                    <div className="invalid-feedback">Campo Obrigatorio</div>
                                </div>
                                <div className="mb-3 col-6 text-dark">
                                    <label className="form-label">Bairro</label>
                                    <input asp-for="Nome" type="text" className="form-control" value={bairro} onChange={(e) => setBairro(e.target.value)} id="" required />
                                    <div className="invalid-feedback">Campo Obrigatorio</div>
                                </div>
            
                                <div className="mb-3 col-6 text-dark">
                                    <label className="form-label">Cidade</label>
                                    <input asp-for="Nome" type="text" className="form-control" value={cidade} onChange={(e) => setCidade(e.target.value)} id="" required />
                                    <div className="invalid-feedback">Campo Obrigatorio</div>
                                </div>
                                <div className="mb-3 col-6 text-dark">
                                    <label className="form-label">Estado</label>
                                    <input asp-for="Nome" type="text" className="form-control" value={estado} onChange={(e) => setEstado(e.target.value)} id="" required />
                                    <div className="invalid-feedback">Campo Obrigatorio</div>
                                </div>
                  
                                <div className="mb-3 col-6 text-dark">
                                    <label className="form-label">complemento</label>
                                    <input asp-for="Nome" type="text" className="form-control" value={complemento} onChange={(e) => setcomplemento(e.target.value)} id="" required />
                                    <div className="invalid-feedback">Campo Obrigatorio</div>
                                </div>
                            </div>




                            <div className="d-grid gap-2 d-md-flex justify-content-md-end mt-2">
                                <Link className="btn btn-secondary" to="/Clientes">
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

export default CadastroClientePage;