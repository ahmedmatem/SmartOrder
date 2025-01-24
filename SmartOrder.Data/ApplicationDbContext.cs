using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartOrder.Data.Models;

namespace SmartOrder.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext()
        {
            
        }

        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}
