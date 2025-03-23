using AutoMapper;
using LogiCommerce.Domain.AggregateModels.ProductAggregate;
using LogiCommerce.Domain.AggregateModels.ProductAggregate.Specification;
using LogiCommerce.SharedKernel.BaseClasses;
using MediatR;

namespace LogiCommerce.Application.Product.Queries.GetProductsByKeywordOrMinMaxStock;

public class GetProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
    : IRequestHandler<GetProductsQuery, BaseServiceResponse<List<GetProductsQueryDto>>>
{
    public async Task<BaseServiceResponse<List<GetProductsQueryDto>>> Handle(GetProductsQuery request,
        CancellationToken cancellationToken)
    {
        var getProductsFilterSpecification = new ProductFilterSpecification(request.Keyword, request.MinStock, request.MaxStock);
        var getProductsFilterData = await productRepository.ListAsync(getProductsFilterSpecification, cancellationToken);

        var mappedProducts = mapper.Map<List<GetProductsQueryDto>>(getProductsFilterData);

        return BaseServiceResponse<List<GetProductsQueryDto>>.Success(mappedProducts, 200);
    }
}