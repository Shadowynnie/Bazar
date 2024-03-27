using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static System.Collections.Specialized.BitVector32;
using Bazar.Models;

namespace Bazar.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Item>()
                .HasIndex(u => u.Name)
                .IsUnique();


        }

        public DbSet<Item> Items { get; set; }
        //public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        
    }
}
