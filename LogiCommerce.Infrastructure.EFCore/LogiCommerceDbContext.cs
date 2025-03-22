using LogiCommerce.Domain.AggregateModels.CategoryAggregate;
using LogiCommerce.Domain.AggregateModels.ProductAggregate;
using Microsoft.EntityFrameworkCore;

namespace LogiCommerce.Infrastructure.EFCore;

public class LogiCommerceDbContext : DbContext
{
    public LogiCommerceDbContext(DbContextOptions<LogiCommerceDbContext> options) : base(options) { }
    
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Category>()
            .Property(c => c.MinStockLevel)
            .IsRequired();
        
        modelBuilder.Entity<Product>()
            .Property(p => p.Title)
            .IsRequired()
            .HasMaxLength(200);
        
        modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}