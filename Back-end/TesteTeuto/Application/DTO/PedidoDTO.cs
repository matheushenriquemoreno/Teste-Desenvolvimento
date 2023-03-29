using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entidades;

namespace Application.DTO
{
    public class PedidoDTO
    {
        public int Id { get; set; }

        public ClienteDTO Cliente { get; set; }

        public EnderecoDTO EnderecoEntrega { get; private set; }

        public List<ItemPedidoDTO> Produtos { get; set; }

        public decimal ValorTotal { get; set; }
    }
}
