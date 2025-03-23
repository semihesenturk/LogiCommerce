using System.ComponentModel.DataAnnotations;
using LogiCommerce.Domain.AggregateModels.ProductAggregate;
using LogiCommerce.Domain.Generics;
using LogiCommerce.SharedKernel.MarkupInterfaces;

namespace LogiCommerce.Domain.AggregateModels.CategoryAggregate;

public class Category : BaseEntity, IAggregateRoot
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    public int MinStockLevel { get; set; } 

    public ICollection<Product> Products { get; set; } = new List<Product>();
}