using LogiCommerce.SharedKernel.BaseClasses;
using MediatR;

namespace LogiCommerce.Application.Product.Queries.GetProductsByKeyword;

public class GetProductsByKeywordQuery : IRequest<BaseServiceResponse<List<GetProductsByKeywordQueryDto>>>
{
    public string Keyword { get; set; }
}