using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entidades.Base;
using Domain.Enums;
using Domain.Exceptions;

namespace Domain.Entidades
{
    public class Pedido : Auditoria
    {
        public Cliente Cliente { get;  private set; }
        public Endereco EnderecoEntrega { get; private set; }
        public ICollection<ItemPedido> Produtos { get; private set; }
        public StatusPedido Status { get; private set; } 
        public decimal ValorTotal { get; private set; }

        protected Pedido() { }

        public Pedido(Cliente cliente, List<ItemPedido> produtos, Endereco enderecoEntrega)
        {
            cliente.ObjetoNaoPodeSerNullo("Necessario um Cliente ao criar um pedido");

            if (!cliente.ClienteStatus.EstaAtivo())
                throw new OperacaoInvalidaException("Somente cliente ativos podem fazer pedidos.");

            Status = StatusPedido.Comcluido;
            Cliente = cliente;
            Produtos = produtos;
            EnderecoEntrega = enderecoEntrega;
            ValorTotal = Produtos.Sum(x => x.Valor);
        }


        public void CancelarPedido()
        {
            Status = StatusPedido.Cancelado;
        }
    }
}
