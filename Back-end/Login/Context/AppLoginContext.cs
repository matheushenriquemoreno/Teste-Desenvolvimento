using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Login.data
{
    public class AppLoginContext : IdentityDbContext<IdentityUser>
    {
        public AppLoginContext(DbContextOptions<AppLoginContext> options)
        : base(options) { }
    }
}
