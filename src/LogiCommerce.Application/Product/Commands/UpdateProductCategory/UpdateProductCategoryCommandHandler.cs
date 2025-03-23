using LogiCommerce.Domain.AggregateModels.CategoryAggregate;
using LogiCommerce.Domain.AggregateModels.CategoryAggregate.Specification;
using LogiCommerce.Domain.AggregateModels.ProductAggregate;
using LogiCommerce.Domain.AggregateModels.ProductAggregate.Specification;
using LogiCommerce.SharedKernel.BaseClasses;
using MediatR;

namespace LogiCommerce.Application.Product.Commands.UpdateProductCategory;

public class UpdateProductCategoryCommandHandler(
    IProductRepository productRepository,
    ICategoryRepository categoryRepository)
    : IRequestHandler<UpdateProductCategoryCommand, BaseServiceResponse<bool>>
{
    public async Task<BaseServiceResponse<bool>> Handle(UpdateProductCategoryCommand request,
        CancellationToken cancellationToken)
    {
        var getProductByIdSpecification = new GetProductByIdSpecification(request.ProductId);
        var productData = await productRepository.FirstOrDefaultAsync(getProductByIdSpecification, cancellationToken);
        if (productData == null)
            return BaseServiceResponse<bool>.Fail("Product not found", 404);

        var getCategoryByIdSpecification = new GetCategoryByIdSpecification(request.NewCategoryId);
        var categoryData =
            await categoryRepository.FirstOrDefaultAsync(getCategoryByIdSpecification, cancellationToken);
        if (categoryData == null)
            return BaseServiceResponse<bool>.Fail("Category not found", 404);

        productData.UpdateCategory(request.NewCategoryId);
        await productRepository.UpdateAsync(productData, cancellationToken);
        var result = await productRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

        return BaseServiceResponse<bool>.Success(result > 0, 200);
    }
}