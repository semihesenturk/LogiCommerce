namespace LogiCommerce.Domain.Generics;

public abstract class BaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedOn { get; set; }
    public DateTime? DeletedOn { get; set; }
    
    public bool IsDeleted => DeletedOn.HasValue;
}