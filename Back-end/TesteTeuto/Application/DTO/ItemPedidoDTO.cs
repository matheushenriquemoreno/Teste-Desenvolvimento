using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class ItemPedidoDTO
    {
        public int Id { get; set; }
        public ProdutoDTO Produto { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; } 
    }
}
