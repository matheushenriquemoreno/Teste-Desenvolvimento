import ReactDOM from 'react-dom/client'
import './index.css'
import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap-icons/font/bootstrap-icons.css";
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import ClientePage from './Pages/Cliente/ClientePage';
import CadastroClientePage from './Pages/Cliente/CadastroClientePage';
import CadastroProdutoPage from './Pages/Produto/CadastroProdutoPage';
import PedidosPage from './Pages/Pedidos/PedidosPage';
import ProdutosPage from './Pages/Produto/ProdutosPage';
import LoginPage from './Pages/Login/LoginPage';
import Auth from './Pages/Login/Auth';
import App from './App';
import Cadastro from './Pages/Login/Cadastro'
import Compra from './Pages/Compra/CompraPage'


ReactDOM.createRoot(document.getElementById('root') as HTMLElement).render(
  <BrowserRouter basename={''}>
    <Routes>
      <Route path='/auth' element={<Auth />}>
        <Route path='login' element={<LoginPage />} />
        <Route path='cadastro' element={<Cadastro />} />
      </Route>

      <Route path='/' element={<App />}>
        <Route path="/Clientes" element={<ClientePage />} />
        <Route path="/Pedidos" element={<PedidosPage />} />
        <Route path="/Produtos" element={<ProdutosPage />} />
        <Route path="/Cliente/Cadastro" element={<CadastroClientePage />} />
        <Route path="/Cliente/Edicao/:Id" element={<CadastroClientePage />} />
        <Route path="/Produto/Cadastro" element={<CadastroProdutoPage />} />
        <Route path="/Produto/Edicao/:Id" element={<CadastroProdutoPage />} />
        <Route path="/Compra" element={<Compra />} />
      </Route>
    </Routes>
  </BrowserRouter>
)
