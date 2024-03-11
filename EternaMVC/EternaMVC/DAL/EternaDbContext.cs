using EternaMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace EternaMVC.DAL
{
    public class EternaDbContext : DbContext
    {
        public EternaDbContext(DbContextOptions<EternaDbContext> options) : base(options)
        {
            
        }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }

    }
}
