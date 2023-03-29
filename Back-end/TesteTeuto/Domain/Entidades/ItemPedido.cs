using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entidades.Base;
using Domain.Exceptions;

namespace Domain.Entidades
{
    public class ItemPedido : EntidadeBase
    {
        public Produto Produto { get; private set; }
        public Pedido PedidoDoProduto { get; private set; }
        public decimal Valor { get; private set; }
        public int Quantidade { get; private set; }

        protected ItemPedido() {}

        public ItemPedido(Produto produto, int quantidade)
        {
            if (quantidade == 0)
                throw new OperacaoInvalidaException("ao fazer um pedido e necessario uma quantidade previamente informada.");

            if (quantidade == 0)
                throw new OperacaoInvalidaException("ao fazer um pedido e necessario uma quantidade previamente informada.");


            if (!produto.StatusDoProduto.EstaAtivo())
                throw new OperacaoInvalidaException("Pedidos podem ser feitos somente para produtos Ativos.");

            produto.DiminuirEstoque(quantidade);

            Produto = produto;
            Valor = produto.Valor * quantidade;
            Quantidade = quantidade;
        }
    }
}
