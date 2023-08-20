using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Web.Observer.Models;

namespace BaseProject.Models
{
    public class AppIdentityDbContext:IdentityDbContext<AppUser>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> opt):base(opt)
        {
            
        }

        public DbSet<Discount> Discounts { get; set; }  
    }
}
