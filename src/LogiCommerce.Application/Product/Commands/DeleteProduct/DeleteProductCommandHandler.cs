using LogiCommerce.Domain.AggregateModels.ProductAggregate;
using LogiCommerce.Domain.AggregateModels.ProductAggregate.Specification;
using LogiCommerce.SharedKernel.BaseClasses;
using MediatR;

namespace LogiCommerce.Application.Product.Commands.DeleteProduct;

public class DeleteProductCommandHandler(IProductRepository productRepository)
    : IRequestHandler<DeleteProductCommand, BaseServiceResponse<bool>>
{
    public async Task<BaseServiceResponse<bool>> Handle(DeleteProductCommand request,
        CancellationToken cancellationToken)
    {
        var getProductByIdSpecification = new GetProductByIdSpecification(request.ProductId);
        var product = await productRepository.FirstOrDefaultAsync(getProductByIdSpecification, cancellationToken);
        if (product == null)
            return BaseServiceResponse<bool>.Fail("Product not found", 404);


        product.Delete();

        await productRepository.UpdateAsync(product, cancellationToken);
        var result = await productRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

        return BaseServiceResponse<bool>.Success(result > 0, 200);
    }
}