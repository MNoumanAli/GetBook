using GetBook.Models;
using Microsoft.EntityFrameworkCore;

namespace GetBook.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Category> Category { get; set; }
    }
}
