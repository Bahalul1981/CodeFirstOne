using CodeFirstTest.Model;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstTest.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
 

        public virtual DbSet<Product> Products { get; set; }

    }
}
