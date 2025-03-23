using AutoMapper;
using LogiCommerce.Domain.AggregateModels.ProductAggregate;
using LogiCommerce.Domain.AggregateModels.ProductAggregate.Specification;
using LogiCommerce.SharedKernel.BaseClasses;
using MediatR;

namespace LogiCommerce.Application.Product.Commands.UpdateProduct;

public class UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
    : IRequestHandler<UpdateProductCommand, BaseServiceResponse<UpdateProductCommandDto>>
{
    public async Task<BaseServiceResponse<UpdateProductCommandDto>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var getProductByIdSpecification = new GetProductByIdSpecification(request.ProductId);
        var product = await productRepository.FirstOrDefaultAsync(getProductByIdSpecification, cancellationToken);
        if (product == null)
            return BaseServiceResponse<UpdateProductCommandDto>.Fail("Product not found", 404);

        //Update Basic Infos
        product.Title = request.Title;
        product.Description = request.Description;
        product.StockQuantity = request.StockQuantity;

        await productRepository.UpdateAsync(product, cancellationToken);
        await productRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

        var updatedProductDto = mapper.Map<UpdateProductCommandDto>(product);

        return BaseServiceResponse<UpdateProductCommandDto>.Success(updatedProductDto, 200);
    }
}