namespace LogiCommerce.Application.Category.Queries.GetCategoryProducts;

public class GetCategoryWithProductsQueryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int MinStockLevel { get; set; } 
    public List<GetCategoryWithProductsProductDto> Products { get; set; } = new();
}

public class GetCategoryWithProductsProductDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int StockQuantity { get; set; }
    public bool IsLive { get; set; }
}