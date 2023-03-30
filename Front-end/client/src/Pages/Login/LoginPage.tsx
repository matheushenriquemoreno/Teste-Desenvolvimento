import { useState } from "react";
import loginIMG from "../../assets/login.svg"
import { LogarUsuario } from "../../Services/Apis/apiLogin";
import { Link, useNavigate } from "react-router-dom";
import { useForm } from "react-hook-form";
import Login from "../../Interfaces/login";
import * as yup from "yup"
import { yupResolver } from '@hookform/resolvers/yup';
import { Button } from 'antd';

const loginValidadeSchema = yup.object({
    email: yup.string().required("Email obrigatorio!").email("Digite um email valido"),
    senha: yup.string().required("Senha obrigatoria!").min(8, "Senha com no minimo 8 caracteres").matches(/(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?!.*\s)(?=.*[!@#$*])/,
        "A senha deve conter pelo menos uma letra maiúscula, minúscula letra, dígito e símbolo especial.")
})


const LoginPage = () => {
    const [errorAtuentificacao, setErrorAtuentificacao] = useState<boolean>(false);
    const [carregandoLogin, setcarregandoLogin] = useState<boolean>(false);
    const navigate = useNavigate();

    const {
        register,
        handleSubmit,
        formState: { errors },
    } = useForm<Login>({ resolver: yupResolver(loginValidadeSchema), mode: "all" });

    async function logar({email, senha}: Login) {
        setcarregandoLogin(true)
        var result = await LogarUsuario({ email: email, senha: senha });

        if (result.sucess) {
            navigate("/Clientes")
        } else {
            setErrorAtuentificacao(true)
            setcarregandoLogin(false)
        }
    }

    return (
        <div className="container login-page">
            <div className="d-flex justify-content-center">
                <div className="col-12 col-md-9" id="form-container">
                    <div className="row align-items-center gx-5">
                        <div className="col-md-6 order-md-2 ">
                            <h3 className="text-center mb-4"> Faça seu login para continuar </h3>
                            <form id="form-container" className="needs-validation" noValidate onSubmit={handleSubmit(logar)}>
                                <div className="form-floating mb-4 mt-4">
                                    <input type="email" className="form-control"
                                        {...register("email")}
                                    />
                                    <label className="form-label"  >Email:</label>

                                    <div className="text-danger mt-1">
                                        {errors.email?.message}
                                    </div>
                                </div>
                                <div className="form-floating mb-3 mt-2 ">
                                    <input type="password" className="form-control"
                                        {...register("senha")}
                                    />
                                    <label className="form-label">Senha:</label>

                                    <div className="text-danger mt-1">
                                        {errors.senha?.message}
                                    </div>
                                </div>
                                <Button loading={carregandoLogin} className="bg-dark" type="primary" htmlType="submit" size="large">Logar</Button>
                            </form>
                        </div>
                        <div className="col-md-6 order-md-1">
                            <div className="col-12">
                                <img src={loginIMG} className="img-fluid" />
                            </div>
                            <div className="col-12" id="link-container">
                                <Link to={"/auth/cadastro"}>
                                    Ainda não tem cadastro?
                                </Link>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            {errorAtuentificacao &&
                <div className="d-flex justify-content-center mt-5">
                    <div className="col-6 alert alert-danger text-center" role="alert">
                        <span>Login ou senha invalidos</span>
                    </div>

                </div>
            }

        </div>



    )
}

export default LoginPage;