using System.ComponentModel.DataAnnotations;

namespace LoginAPI.DTO
{
    public class RegisterDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "confirma senha")]
        [Compare("Senha", ErrorMessage = "Senhas não conferem")]
        public string ComfirmarSenha { get; set; }
    }
}
