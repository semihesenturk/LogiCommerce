using LogiCommerce.SharedKernel.BaseClasses;
using MediatR;

namespace LogiCommerce.Application.Product.Queries.GetProductsByKeywordOrMinMaxStock;

public class GetProductsQuery : IRequest<BaseServiceResponse<List<GetProductsByKeywordQueryDto>>>
{
    public string? Keyword { get; set; }
    public int? MinStock { get; set; }
    public int? MaxStock { get; set; }

    public GetProductsQuery(string? keyword, int? minStock, int? maxStock)
    {
        Keyword = keyword;
        MinStock = minStock;
        MaxStock = maxStock;
    }
}