using LogiCommerce.SharedKernel.BaseClasses;
using MediatR;

namespace LogiCommerce.Application.Product.Queries.GetProductsByKeywordOrMinMaxStock;

public class GetProductsQuery(string? keyword, int? minStock, int? maxStock)
    : IRequest<BaseServiceResponse<List<GetProductsQueryDto>>>
{
    public string? Keyword { get; set; } = keyword;
    public int? MinStock { get; set; } = minStock;
    public int? MaxStock { get; set; } = maxStock;
}