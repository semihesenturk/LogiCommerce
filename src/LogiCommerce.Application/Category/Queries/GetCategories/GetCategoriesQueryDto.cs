namespace LogiCommerce.Application.Category.Queries.GetCategories;

public class GetCategoriesQueryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<ProductDto> Products { get; set; } = [];
}

public class ProductDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int StockQuantity { get; set; }
}