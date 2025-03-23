namespace LogiCommerce.Application.Product.Queries.GetProductById;

public class GetProductByIdQueryDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int StockQuantity { get; set; }
    public bool IsLive { get; set; }
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; }
}