using Microsoft.AspNetCore.Identity;

namespace LoginAPI.Services
{
    public interface IAutentificacao
    {
        Task<(bool foiAutentificado, IdentityUser user)> Atentificar(string email, string password);
        Task<bool> CriarUsuario(string email, string password);
        Task<IEnumerable<IdentityUser>> UsuariosCadastrados();
        Task logout();
    }
}
