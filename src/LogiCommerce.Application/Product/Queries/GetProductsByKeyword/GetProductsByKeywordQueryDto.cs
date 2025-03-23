namespace LogiCommerce.Application.Product.Queries.GetProductsByKeyword;

public class GetProductsByKeywordQueryDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int StockQuantity { get; set; }
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; }
}