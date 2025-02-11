using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartOrder.Data.Configuration;
using SmartOrder.Data.Models;

namespace SmartOrder.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext()
        {
            
        }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Venue> Venues { get; set; } = null!;
        public virtual DbSet<Table> Tables { get; set; } = null!;
        public virtual DbSet<MenuCategory> MenuCategories { get; set; } = null!;
        public virtual DbSet<MenuItem> MenuItems { get; set; } = null!;
        public virtual DbSet<OrderItem> OrderItems { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            SeedData data = new SeedData();

            builder.Entity<Venue>().HasData(data.FirstVenue, data.SecondVenue, data.ThirdVenue);
            builder.Entity<IdentityRole<Guid>>().HasData(data.AdminRole, data.ManagerRole, data.WaiterRole);
            builder.Entity<ApplicationUser>().HasData(data.FirstVenueWaiterUser, data.SecondVenueWaiterUser, data.ThirdVenueWaiterUser,
                data.FirstVenueManagerUser, data.SecondVenueManagerUser, data.ThirdVenueManagerUser, data.AdminUser);
            builder.Entity<IdentityUserRole<Guid>>().HasData(data.UsersInRoles);
            builder.Entity<Table>().HasData(data.FirstVenueTables);
            builder.Entity<Table>().HasData(data.SecondVenueTables);
            builder.Entity<Table>().HasData(data.ThirdVenueTables);
            builder.Entity<MenuCategory>().HasData(data.FirstVenueMenuCategories);
            builder.Entity<MenuCategory>().HasData(data.SecondVenueMenuCategories);
            builder.Entity<MenuCategory>().HasData(data.ThirdVenueMenuCategories);
            builder.Entity<MenuItem>().HasData(data.FirstVenueMenuItems);
            builder.Entity<MenuItem>().HasData(data.SecondVenueMenuItems);
            builder.Entity<MenuItem>().HasData(data.ThirdVenueMenuItems);

            base.OnModelCreating(builder);
        }
    }
}
