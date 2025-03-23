using FluentValidation;
using LogiCommerce.Domain.AggregateModels.CategoryAggregate;
using LogiCommerce.Domain.AggregateModels.CategoryAggregate.Specification;
using LogiCommerce.Domain.AggregateModels.ProductAggregate;
using LogiCommerce.SharedKernel.BaseClasses;
using MediatR;
using ValidationException = FluentValidation.ValidationException;

namespace LogiCommerce.Application.Product.Commands.CreateProduct;

public class CreateProductCommandHandler(IProductRepository productRepository, ICategoryRepository categoryRepository, IValidator<CreateProductCommand> validator) : IRequestHandler<CreateProductCommand, BaseServiceResponse<CreateProductCommandDto>>
{
    public async Task<BaseServiceResponse<CreateProductCommandDto>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        // Validate the command using FluentValidation
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        
        //Check category information
        var getCategoryByIdSpecification = new GetCategoryByIdSpecification(request.CategoryId);
        var categoryData = await categoryRepository.FirstOrDefaultAsync(getCategoryByIdSpecification, cancellationToken);
        if (categoryData == null)
            return BaseServiceResponse<CreateProductCommandDto>.Fail("Category not found", 404);
        
        
        var product = new Domain.AggregateModels.ProductAggregate.Product
        {
            Title = request.Title,
            Description = request.Description,
            StockQuantity = request.StockQuantity,
            CategoryId = request.CategoryId
        };

        await productRepository.AddAsync(product, cancellationToken);
        var result = await productRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

        return result == 0
            ? BaseServiceResponse<CreateProductCommandDto>.Success(
                new CreateProductCommandDto { Id = Guid.Empty, Result = false }, 500)
            : BaseServiceResponse<CreateProductCommandDto>.Success(
                new CreateProductCommandDto { Id = product.Id, Result = true }, 200);
    }
}