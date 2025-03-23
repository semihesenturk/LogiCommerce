namespace LogiCommerce.Application.Product.Commands.UpdateProduct;

public class UpdateProductCommandDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int StockQuantity { get; set; }
}