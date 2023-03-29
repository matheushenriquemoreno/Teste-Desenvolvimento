using System.ComponentModel.DataAnnotations;

namespace LoginAPI.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Email é Obrigatorio")]
        [EmailAddress(ErrorMessage = "Formato de email inválido")]
        public string  Email { get; set; }

        [Required(ErrorMessage = "Senha é Obrigatorio")]
        [StringLength(20, ErrorMessage =" A {0} no mínimo {2} e no máximo {1} caracteres", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

    }
}
