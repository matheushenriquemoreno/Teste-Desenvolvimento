using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class PedidoCreateDTO
    {
        [Required]
        public int IdCliente { get; set; }
        [Required]
        public List<CreateItemPedidoDTO> Produtos { get; set; }
    }
}
