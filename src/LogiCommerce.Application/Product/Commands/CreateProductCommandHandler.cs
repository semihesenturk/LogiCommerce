using LogiCommerce.Domain.AggregateModels.ProductAggregate;
using LogiCommerce.SharedKernel.BaseClasses;
using MediatR;

namespace LogiCommerce.Application.Product.Commands;

public class CreateProductCommandHandler(IProductRepository productRepository) : IRequestHandler<CreateProductCommand, BaseServiceResponse<CreateProductCommandDto>>
{
    public async Task<BaseServiceResponse<CreateProductCommandDto>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Domain.AggregateModels.ProductAggregate.Product
        {
            Title = request.Title,
            Description = request.Description,
            StockQuantity = request.StockQuantity,
            CategoryId = request.CategoryId
        };

        await productRepository.AddAsync(product);
        var result = await productRepository.UnitOfWork.SaveChangesAsync();

        return result == 0
            ? BaseServiceResponse<CreateProductCommandDto>.Success(
                new CreateProductCommandDto { Id = Guid.Empty, Result = false }, 500)
            : BaseServiceResponse<CreateProductCommandDto>.Success(
                new CreateProductCommandDto { Id = product.Id, Result = true }, 200);
    }
}