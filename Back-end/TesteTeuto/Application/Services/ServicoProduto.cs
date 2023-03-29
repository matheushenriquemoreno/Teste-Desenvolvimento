using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Domain.Entidades;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Interfaces.Repositorio;

namespace Application.Services
{
    public class ServicoProduto : IServicoProduto
    {
        private readonly IMapper mapper;
        private readonly IRepositorioProduto repositorioProduto;

        public ServicoProduto(IRepositorioProduto repositorioProduto, IMapper mapper)
        {
            this.repositorioProduto = repositorioProduto;
            this.mapper = mapper;
        }

        public async Task<ProdutoDTO> Add(ProdutoDTO ProdutoDTO, string emailUsuarioLogado)
        {
            var produto = new Produto(ProdutoDTO.NomeProduto,ProdutoDTO.Quatidade, ProdutoDTO.Valor, ProdutoDTO.Descricao, ProdutoDTO.StatusDoProduto);

            produto.RegistrarAuditoriaCriacao(emailUsuarioLogado);

            await repositorioProduto.Adicionar(produto);

            return mapper.Map<ProdutoDTO>(produto);
        }

        public async Task Atualizar(ProdutoDTO ProdutoDTO, string emailUsuarioLogado)
        {
            var produto = await repositorioProduto.ObterPorIdAsync(ProdutoDTO.Id);

            produto.ObjetoNaoPodeSerNullo("Não pode atualizar um produto Inexistente");

            produto.Atualizar(ProdutoDTO.NomeProduto,ProdutoDTO.Quatidade, ProdutoDTO.Valor, ProdutoDTO.Descricao, ProdutoDTO.StatusDoProduto);

            produto.RegistrarAuditoriaAlteracao(emailUsuarioLogado);

            await repositorioProduto.Update(produto);
        }

        public async Task<ProdutoDTO> ObterProdutoPeloID(int id)
        {
            var produto = await repositorioProduto.ObterPorIdAsync(id);
            return mapper.Map<ProdutoDTO>(produto);
        }

        public async Task<IEnumerable<ProdutoDTO>> ObterProdutosAtivos()
        {
            var produtos = await repositorioProduto.ObterTodosOnde(x => x.Quatidade > 0 && x.StatusDoProduto == Status.Ativo);

            return mapper.Map<IEnumerable<ProdutoDTO>>(produtos);
        }

        public async Task<IEnumerable<ProdutoDTO>> ObterProdutos()
        {
            var produtos = await repositorioProduto.ObterTodosAsync();

            return mapper.Map<IEnumerable<ProdutoDTO>>(produtos);
        }

        public async Task Remove(int id)
        {
            var produto = await repositorioProduto.ObterPorIdAsync(id);

            produto.ObjetoNaoPodeSerNullo("Não pode excluir um produto Inexistente");

            if (produto.PedidosDoProduto.Count() > 0)
                throw new OperacaoInvalidaException("Não pode excluir produtos que ja possuem pedidos");

            await repositorioProduto.Remover(produto);
        }
    }
}
