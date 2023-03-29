using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Application.DTO
{
    public class ProdutoDTO
    {
        public int Id { get; set; }
        [Required]
        public string NomeProduto { get; set; } 
        [Required]
        public string Descricao { get; set; }
        [Required]
        public decimal Valor { get; set; }
        [Required]
        public int Quatidade { get; set; }
        [Required]
        public Status StatusDoProduto { get; set; }

    }
}
