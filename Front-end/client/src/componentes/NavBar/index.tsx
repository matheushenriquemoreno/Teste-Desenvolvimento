import { Link, useNavigate } from "react-router-dom";
import "./index.css"
import React, { useEffect, useState } from "react";

const Navbar = () => {
  const [emailUser, setEmailUser] = useState<string>();
  const navigate = useNavigate();

  function logout() {
    localStorage.clear()
    navigate("/auth/login")
  }

  useEffect(() => {
    setEmailUser(localStorage.getItem("email") ?? "")
  }, [])

  return (
    <React.Fragment>
      <nav className="navbar navbar-expand-lg bg-dark mb-5">
        <div className="container-fluid">
          <a className="navbar-brand text-white" href="#">Bem vindo </a>
          <a className="nav-link text-white"><i className="bi bi-person-circle"></i> {emailUser}</a>
          <button className="navbar-toggler bg-light" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavAltMarkup" aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
            <span className="navbar-toggler-icon"></span>
          </button>
          <div className="collapse navbar-collapse" id="navbarNavAltMarkup">
            <div className="navbar-nav">
              <Link to="/Clientes" className="nav-link text-white"> <i className="bi bi-people-fill"></i> Clientes </Link>
              <Link to="/Produtos" className="nav-link  text-white "> <i className="bi bi-bag-check-fill"></i> Produtos </Link>
              <Link to="/Compra" className="nav-link  text-white "> <i className="bi bi-cart-fill"></i> Comprar produtos </Link>
              <Link to="/Pedidos" className="nav-link  text-white "> <i className="bi bi-bag-fill"></i> Pedidos Realizado </Link>
            </div>
          </div>

          <button type="button" className="btn btn-outline-light me-2 text-end" onClick={logout}>Sair</button>
        </div>
      </nav>
    </React.Fragment>
  )
}


export default Navbar;
