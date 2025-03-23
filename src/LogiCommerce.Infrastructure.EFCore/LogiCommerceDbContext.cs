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

public void Seed()
    {
        if (!Categories.Any())
        {
            Categories.AddRange(
                new Category
                {
                    Name = "Electronics",
                    MinStockLevel = 10
                },
                new Category
                {
                    Name = "Clothing",
                    MinStockLevel = 20
                }
            );

            SaveChanges();
        }

        if (!Products.Any())
        {
            var electronicsCategory = Categories.First(c => c.Name == "Electronics");
            var clothingCategory = Categories.First(c => c.Name == "Clothing");

            Products.AddRange(
                new Product
                {
                    Title = "Laptop",
                    Description = "A powerful laptop",
                    StockQuantity = 50,
                    CategoryId = electronicsCategory.Id
                },
                new Product
                {
                    Title = "Smartphone",
                    Description = "Latest model smartphone",
                    StockQuantity = 100,
                    CategoryId = electronicsCategory.Id
                },
                new Product
                {
                    Title = "Headphones",
                    Description = "Noise cancelling headphones",
                    StockQuantity = 30,
                    CategoryId = electronicsCategory.Id
                },
                new Product
                {
                    Title = "Smartwatch",
                    Description = "Wearable tech smartwatch",
                    StockQuantity = 20,
                    CategoryId = electronicsCategory.Id
                },
                new Product
                {
                    Title = "Tablet",
                    Description = "10-inch tablet",
                    StockQuantity = 15,
                    CategoryId = electronicsCategory.Id
                },
                
                new Product
                {
                    Title = "T-shirt",
                    Description = "Comfortable cotton t-shirt",
                    StockQuantity = 150,
                    CategoryId = clothingCategory.Id
                },
                new Product
                {
                    Title = "Jeans",
                    Description = "Stylish denim jeans",
                    StockQuantity = 200,
                    CategoryId = clothingCategory.Id
                },
                new Product
                {
                    Title = "Jacket",
                    Description = "Warm winter jacket",
                    StockQuantity = 60,
                    CategoryId = clothingCategory.Id
                },
                new Product
                {
                    Title = "Sneakers",
                    Description = "Comfortable running shoes",
                    StockQuantity = 80,
                    CategoryId = clothingCategory.Id
                },
                new Product
                {
                    Title = "Hat",
                    Description = "Stylish summer hat",
                    StockQuantity = 40,
                    CategoryId = clothingCategory.Id
                }
            );

            SaveChanges();
        }
    }
    
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