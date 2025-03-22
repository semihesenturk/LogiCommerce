using Ardalis.Specification;

namespace LogiCommerce.Domain.AggregateModels.ProductAggregate.Specification;

public class GetProductByStockRangeSpecification : Specification<Product>
{
    public GetProductByStockRangeSpecification(int minStock, int maxStock)
    {
        Query.Where(p => p.StockQuantity >= minStock && p.StockQuantity <= maxStock);
    }
}