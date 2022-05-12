using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiProjectTest.Models
{
    public class EcommerceDB:IdentityDbContext<ApplicationUser>
    {
        public EcommerceDB()
        {

        }

        public EcommerceDB(DbContextOptions options):base(options)
        {

        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
