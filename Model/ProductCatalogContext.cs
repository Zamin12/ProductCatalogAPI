using Microsoft.EntityFrameworkCore;

namespace ProductCatalogAPI.Model
{
    public class ProductCatalogContext : DbContext
    {
        public ProductCatalogContext(DbContextOptions<ProductCatalogContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            ConfigureProducts(modelBuilder);
        }
        private void ConfigureProducts(ModelBuilder modelBuilder)
        {
            // "Code" field is required
            modelBuilder.Entity<Product>()
                .Property(x => x.Code)
                .IsRequired(true);

            // "Code" field is unique contraint
            modelBuilder.Entity<Product>()
                .HasIndex(x => x.Code)
                .IsUnique();

            // "Name" field is required
            modelBuilder.Entity<Product>()
                .Property(x => x.Name)
                .IsRequired();

            // "Price" field is required
            modelBuilder.Entity<Product>()
                .Property(x => x.Price)
                .IsRequired();

            // "Price" field is set to default precision and scale.
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            // "LastUpdated" field is never generated
            modelBuilder.Entity<Product>()
                .Property(x => x.LastUpdated)
                .ValueGeneratedNever();
        }
    }
}
