using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO;

namespace WebAPI.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public abstract class BaseController : ControllerBase
    {
        protected new User User
        {
            get
            {
                var claims = HttpContext?.User.Claims;

                var user = new User
                {
                    Email = claims.FirstOrDefault(c => c.Type == "Email")?.Value,
                };

                return user;
            }
        }
    }
}
