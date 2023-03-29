using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Application.DTO
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public Status ClienteStatus { get; set; }
        public EnderecoDTO Endereco { get; set; }
    }
}
