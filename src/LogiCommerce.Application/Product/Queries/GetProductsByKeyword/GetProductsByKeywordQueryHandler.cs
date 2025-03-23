using AutoMapper;
using LogiCommerce.Domain.AggregateModels.ProductAggregate;
using LogiCommerce.Domain.AggregateModels.ProductAggregate.Specification;
using LogiCommerce.SharedKernel.BaseClasses;
using MediatR;

namespace LogiCommerce.Application.Product.Queries.GetProductsByKeyword;

public class GetProductsByKeywordQueryHandler(IProductRepository productRepository, IMapper mapper)
    : IRequestHandler<GetProductsByKeywordQuery, BaseServiceResponse<List<GetProductsByKeywordQueryDto>>>
{
    public async Task<BaseServiceResponse<List<GetProductsByKeywordQueryDto>>> Handle(GetProductsByKeywordQuery request,
        CancellationToken cancellationToken)
    {
        var getProductsByKeywordSpecification = new GetProductByKeywordSpecification(request.Keyword);
        var getProductsByKeywordResult = await productRepository.ListAsync(getProductsByKeywordSpecification, cancellationToken);

        var mappedProducts = mapper.Map<List<GetProductsByKeywordQueryDto>>(getProductsByKeywordResult);

        return BaseServiceResponse<List<GetProductsByKeywordQueryDto>>.Success(mappedProducts, 200);
    }
}