using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Domain.Entidades;
using Domain.Exceptions;
using Domain.Interfaces.Repositorio;

namespace Application.Services
{
    public class ServicoPedido : IServicoPedido
    {
        private readonly IMapper _mapper;
        public readonly IRepositorioCliente repositorioCliente;
        private readonly IRepositorioProduto repositorioProduto;
        private readonly IRepositorioPedido repositorioPedido;

        public ServicoPedido(IMapper mapper, IRepositorioCliente repositorioCliente, IRepositorioProduto repositorioProduto, IRepositorioPedido repositorioPedido)
        {
            _mapper = mapper;
            this.repositorioCliente = repositorioCliente;
            this.repositorioProduto = repositorioProduto;
            this.repositorioPedido = repositorioPedido;
        }

        public async Task<PedidoDTO> ObterPeloId(int id)
        {
            var pedido = await repositorioPedido.ObterPorIdAsync(id);

            return _mapper.Map<PedidoDTO>(pedido);
        }

        public async Task CriarPedido(PedidoCreateDTO pedidoDTO, string emailUsuarioLogado)
        {
            var cliente = await repositorioCliente.ObterPorIdAsync(pedidoDTO.IdCliente);

            var ItensPedidos = new List<ItemPedido>();

            foreach(var produtoDTO in pedidoDTO.Produtos)
            {
                var produto = await repositorioProduto.ObterPorIdAsync(produtoDTO.IdProduto);

                ItensPedidos.Add(new ItemPedido(produto, produtoDTO.QuantidadeItens));
            }

            var pedido = new Pedido(cliente, ItensPedidos, ObterEnderecoPedido(cliente));

            pedido.RegistrarAuditoriaCriacao(emailUsuarioLogado);

            await repositorioPedido.Adicionar(pedido);
        }

        public async Task CancelarPedido(int idPedido, string emailUsuarioLogado)
        {
            var pedido = await repositorioPedido.ObterPorIdAsync(idPedido);

            pedido.RegistrarAuditoriaAlteracao(emailUsuarioLogado);
            pedido.CancelarPedido();

            await repositorioPedido.Salvar();
        }

        public async Task<IEnumerable<PedidoDTO>> ObterTodosPedidos()
        {
            var pedidos = await repositorioPedido.ObterTodosAsync();

            return _mapper.Map<IEnumerable<PedidoDTO>>(pedidos);
        }

        public async Task<decimal> ObterValorDoPedido(int idProduto, int quantidade)
        {
            var produto = await repositorioProduto.ObterPorIdAsync(idProduto);

            return produto.Valor * quantidade;
        }

        private Endereco ObterEnderecoPedido(Cliente cliente)
        {
            return new Endereco(cliente.Endereco.Rua, cliente.Endereco.Bairro, cliente.Endereco.Cidade, cliente.Endereco.Estado, cliente.Endereco.CEP, cliente.Endereco.Complemento);
        }
    
    }
}
