using LogiCommerce.Domain.AggregateModels.CategoryAggregate;
using LogiCommerce.Domain.AggregateModels.CategoryAggregate.Specification;
using LogiCommerce.Domain.AggregateModels.ProductAggregate;
using LogiCommerce.Domain.AggregateModels.ProductAggregate.Specification;
using LogiCommerce.SharedKernel.BaseClasses;
using MediatR;

namespace LogiCommerce.Application.Product.Commands.SetProductLiveStatus;

public class SetProductLiveStatusCommandHandler(IProductRepository productRepository, ICategoryRepository categoryRepository) 
    : IRequestHandler<SetProductLiveStatusCommand, BaseServiceResponse<bool>>
{
    public async Task<BaseServiceResponse<bool>> Handle(SetProductLiveStatusCommand request, CancellationToken cancellationToken)
    {
        var getProductByIdSpecification = new GetProductByIdSpecification(request.ProductId);
        var product = await productRepository.FirstOrDefaultAsync(getProductByIdSpecification, cancellationToken);
        if (product == null)
            return BaseServiceResponse<bool>.Fail("Product not found", 404);

        // Check if the product has a category assigned
        var getCategoryByIdSpecification = new GetCategoryByIdSpecification(product.CategoryId);
        var category = await categoryRepository.FirstOrDefaultAsync(getCategoryByIdSpecification, cancellationToken);
        if (category == null)
            return BaseServiceResponse<bool>.Fail("Product does not have a valid category", 400);

        // Check if the product's stock is above the minimum stock limit for the category
        if (product.StockQuantity < category.MinStockLevel)
            return BaseServiceResponse<bool>.Fail("Product stock is below the required limit", 400);

        // If all checks pass, set the product to live
        product.SetLiveStatus(true);
        await productRepository.UpdateAsync(product, cancellationToken);

        return BaseServiceResponse<bool>.Success(true, 200);
    }
}