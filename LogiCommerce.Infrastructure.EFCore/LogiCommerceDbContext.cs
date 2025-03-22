using LogiCommerce.Domain.AggregateModels.CategoryAggregate;
using LogiCommerce.Domain.AggregateModels.ProductAggregate;
using LogiCommerce.Domain.Generics;
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

        modelBuilder.Entity<BaseEntity>()
            .Property(x => x.Id);

        modelBuilder.Entity<BaseEntity>()
            .Property(x => x.CreatedOn)
            .HasDefaultValueSql("getutcdate()");

        modelBuilder.Entity<BaseEntity>()
            .Property(x => x.UpdatedOn)
            .IsRequired(false); 

        modelBuilder.Entity<BaseEntity>()
            .Property(x => x.DeletedOn)
            .IsRequired(false);  
        
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