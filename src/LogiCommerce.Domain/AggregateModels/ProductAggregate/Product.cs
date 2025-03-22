using System.ComponentModel.DataAnnotations;
using LogiCommerce.Domain.AggregateModels.CategoryAggregate;

namespace LogiCommerce.Domain.AggregateModels.ProductAggregate;

public class Product 
{
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Title { get; set; }
    public string Description { get; set; }
    public int StockQuantity { get; set; }
    public int CategoryId { get; set; }
    
    public Category Category { get; set; } 
    
    public bool IsLive => StockQuantity >= Category?.MinStockLevel;
    
}