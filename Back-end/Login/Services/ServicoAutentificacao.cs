using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LoginAPI.Services
{
    public class ServicoAutentificacao : IAutentificacao
    {

        private readonly SignInManager<IdentityUser> _gerenciadorLogin;
        private readonly UserManager<IdentityUser> _gerenciadorUsuario;

        public ServicoAutentificacao(SignInManager<IdentityUser> gerenciadorLogin, UserManager<IdentityUser> gerenciadorUsuario)
        {
            _gerenciadorLogin = gerenciadorLogin;
            _gerenciadorUsuario = gerenciadorUsuario;
        }

        public async Task<(bool, IdentityUser)> Atentificar(string email, string password)
        {
            var result = await _gerenciadorLogin.PasswordSignInAsync(email, password, false, false);

            if(result.Succeeded)
            {
               var user = await _gerenciadorUsuario.Users.FirstOrDefaultAsync(x => x.Email.Equals(email));
                return (true,  user);
            }

            return (false, null);
        }

        public async Task<bool> CriarUsuario(string email, string password)
        {
            var user = new IdentityUser
            {
                UserName = email,
                Email = email,
            };

            var result = await _gerenciadorUsuario.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await _gerenciadorLogin.SignInAsync(user, false);
            }

            return result.Succeeded;
        }

        public async Task logout()
        {
            await _gerenciadorLogin.SignOutAsync();
        }
        
        public async Task<IEnumerable<IdentityUser>> UsuariosCadastrados()
        {

            return await _gerenciadorUsuario.Users.ToListAsync();
        }
    }
}
