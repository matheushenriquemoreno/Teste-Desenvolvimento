using Application.Interfaces;

namespace WebAPI.DTO
{
    public class UserAPP : IUser
    {
        private readonly IHttpContextAccessor _accessor;

        public string Email {
            get
            {
                var claims = _accessor.HttpContext?.User.Claims;

                return claims.FirstOrDefault(c => c.Type == "Email")?.Value;
            }
        }

        public UserAPP(IHttpContextAccessor httpContextAccessor)
        {
            this._accessor = httpContextAccessor;
        }
    }
}
