using System.ComponentModel.DataAnnotations;
using LogiCommerce.Domain.AggregateModels.CategoryAggregate;
using LogiCommerce.Domain.Generics;
using LogiCommerce.SharedKernel.MarkupInterfaces;

namespace LogiCommerce.Domain.AggregateModels.ProductAggregate;

public class Product : BaseEntity, IAggregateRoot
{
    [Required]
    [MaxLength(200)]
    public string Title { get; set; }
    public string Description { get; set; }
    public int StockQuantity { get; set; }
    public Guid CategoryId { get; set; }
    
    public Category Category { get; set; } 
    
    public bool IsLive { get; set; }
    
    public void Delete()
    {
        DeletedOn = DateTime.Now;
    }

    public void SetLiveStatus(bool status)
    {
        IsLive = status;
    }
}