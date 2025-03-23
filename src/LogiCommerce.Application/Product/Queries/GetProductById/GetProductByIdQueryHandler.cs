using AutoMapper;
using LogiCommerce.Domain.AggregateModels.ProductAggregate;
using LogiCommerce.Domain.AggregateModels.ProductAggregate.Specification;
using LogiCommerce.SharedKernel.BaseClasses;
using MediatR;

namespace LogiCommerce.Application.Product.Queries.GetProductById;

public class GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
    : IRequestHandler<GetProductByIdQuery, BaseServiceResponse<GetProductByIdQueryDto>>
{
    public async Task<BaseServiceResponse<GetProductByIdQueryDto>> Handle(GetProductByIdQuery request,
        CancellationToken cancellationToken)
    {
        var getProductByIdSpecification = new GetProductByIdSpecification(request.Id);
        var productData = await productRepository.FirstOrDefaultAsync(getProductByIdSpecification, cancellationToken);

        if (productData is null)
            return BaseServiceResponse<GetProductByIdQueryDto>.Fail("Product not found", 404);

        var mappedProduct = mapper.Map<GetProductByIdQueryDto>(productData);

        return BaseServiceResponse<GetProductByIdQueryDto>.Success(mappedProduct, 200);
    }
}