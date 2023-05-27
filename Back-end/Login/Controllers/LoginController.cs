using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LoginAPI.DTO;
using LoginAPI.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames;

namespace LoginAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private IAutentificacao _autentificacao;

        public LoginController(IAutentificacao autentificacao, IConfiguration configuration)
        {
            _autentificacao = autentificacao;
            _configuration = configuration;
        }

        /// <summary>
        /// criação de usuario para toda a aplicação
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("CriarUsuario")]
        public async Task<ActionResult> CriarUsuario([FromBody] RegisterDTO model)
        {
            if (model.Senha != model.ComfirmarSenha)
                return BadRequest(new { message = "As senhas não conferem" });

            var result = await _autentificacao.CriarUsuario(model.Email, model.Senha);

            if (result)
                return Created(nameof(LogarUsuario), new { message = "User criado com sucesso"});

            return BadRequest(new { message = "Erro ao Logar usuario, Verifique suas Credencias " });
        }

        /// <summary>
        /// Efetua o login do usuario com base no email e senha.
        /// </summary>
        /// <param name="model"></param>
        /// <response code="200">Retorna o token caso o login seja efetuado com sucesso</response>
        /// <response code="404">Erro ao logar usuario</response>
        [HttpPost("LogarUsuario")]
        public async Task<ActionResult<TokenUsuario>> LogarUsuario([FromBody] LoginDTO model)
        {
            try
            {
                var result = await _autentificacao.Atentificar(model.Email, model.Senha);

                if (result.foiAutentificado)
                    return CriarToken(result.user);

                return BadRequest(new { message = "Erro ao Logar usuario, Verifique suas Credencias " });
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        [HttpGet("Usuarios")]
        public async Task<ActionResult<IEnumerable<IdentityUser>>> BuscarUsuarios()
        {
            var user = await _autentificacao.UsuariosCadastrados();

            return Ok(user);
        }

        private ActionResult<TokenUsuario> CriarToken(IdentityUser model)
        {
            var claims = new[]
            {
                new Claim("Email", model.Email),
                new Claim("Id", model.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]));

            var credencial = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiracao = DateTime.Now.AddMinutes(10);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: expiracao,
                signingCredentials: credencial);

            return new TokenUsuario()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiracao = expiracao
            };

        }
    }
}
