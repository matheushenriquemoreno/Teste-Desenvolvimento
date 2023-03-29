using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entidades.Base;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Interfaces.Base;

namespace Domain.Entidades
{
    public class Produto : Auditoria
    {
        public string NomeProduto { get; private set; }
        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }
        public int Quatidade { get; private set; }
        public Status StatusDoProduto { get; private set; }
        public ICollection<ItemPedido> PedidosDoProduto { get; private set; }
   
        protected Produto()
        {
            PedidosDoProduto = new List<ItemPedido>();
        }

        public Produto(string nome,int quatidade, decimal valor, string descricao, Status statusProduto)
        {
            Atualizar(nome, quatidade, valor, descricao, statusProduto);
        }

        public void Atualizar(string nome,int quatidade, decimal valor, string descricao, Status statusProduto)
        {
            NomeProduto = nome;
            Quatidade = quatidade;
            Valor = valor;
            Descricao = descricao;
            StatusDoProduto = statusProduto;
        }


        public void DiminuirEstoque(int quantidadeVendidas)
        {
            if (this.Quatidade < quantidadeVendidas)
                throw new OperacaoInvalidaException("Quantidade de Produtos Insuficientes para realização do pedido!");

            this.Quatidade -= quantidadeVendidas;

            if(this.Quatidade == 0) this.StatusDoProduto = Status.Inativo;
        }

    }
}
