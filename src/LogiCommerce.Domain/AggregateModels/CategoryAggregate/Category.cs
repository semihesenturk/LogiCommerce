using System.ComponentModel.DataAnnotations;
using LogiCommerce.Domain.AggregateModels.ProductAggregate;

namespace LogiCommerce.Domain.AggregateModels.CategoryAggregate;

public class Category
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    public int MinStockLevel { get; set; } // Minimum stok seviyesi

    public ICollection<Product> Products { get; set; } = new List<Product>();
}