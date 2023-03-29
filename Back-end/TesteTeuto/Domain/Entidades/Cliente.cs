using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entidades.Base;
using Domain.Enums;

namespace Domain.Entidades
{
    public class Cliente : Auditoria
    {
        public string Nome { get; private set; }

        public Endereco Endereco { get; protected set; }

        public Status ClienteStatus { get; private set; }

        public ICollection<Pedido> PedidosDoCliente { get; protected set; }
        
        protected Cliente() {
            PedidosDoCliente = new List<Pedido>();
        }

        public Cliente(string nome, Status clienteStatus, Endereco endereco)
        {
            this.Nome = nome;
            this.ClienteStatus = clienteStatus;
            this.Endereco = endereco;
        }

        public void AdicionarPedido(Pedido pedido)
        {
            PedidosDoCliente.Add(pedido);
        }

        public void Atualizar(string nome, Status status)
        {
            this.Nome = nome;
            this.ClienteStatus = status;
        }

    }
}
