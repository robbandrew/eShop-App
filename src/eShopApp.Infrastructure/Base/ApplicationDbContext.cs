namespace eShopApp.Infrastructure.Base
{
    using eShopApp.Domain.Products;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {  
        }
        public DbSet<Product> Products { get; set; }

    }
}
