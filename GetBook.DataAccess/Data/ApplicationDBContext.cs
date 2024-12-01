using GetBook.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GetBook.DataAccess.Data
{
    public class ApplicationDBContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = "1" },
                new Category { Id = 2, Name = "History", DisplayOrder = "2" }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "Space Land",
                    Author = "Jon Ae",
                    Description = "Man stuck in Space and build his own Home",
                    ISBN = "AST00912222",
                    ListPrice = 120,
                    Price = 110,
                    Price50 = 90,
                    Price100 = 60,
                    CategoryId = 2,
                    ImageURL = "",
                }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
