using LogiCommerce.Domain.AggregateModels.CategoryAggregate;
using LogiCommerce.SharedKernel.BaseClasses;
using MediatR;

namespace LogiCommerce.Application.Category.Commands.CreateCategory;

public class CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
    : IRequestHandler<CreateCategoryCommand, BaseServiceResponse<CreateCategoryCommandDto>>
{
    public async Task<BaseServiceResponse<CreateCategoryCommandDto>> Handle(CreateCategoryCommand request,
        CancellationToken cancellationToken)
    {
        var categoryData = new Domain.AggregateModels.CategoryAggregate.Category
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            MinStockLevel = request.MinStockLevel,
            CreatedOn = DateTime.UtcNow
        };

        await categoryRepository.AddAsync(categoryData, cancellationToken);
        var result = await categoryRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

        if (result == 0)
            return BaseServiceResponse<CreateCategoryCommandDto>.Fail(
                "Category couldn't be saved!", 500);

        return BaseServiceResponse<CreateCategoryCommandDto>.Success(
            new CreateCategoryCommandDto { Id = categoryData.Id, Result = true }, 200);
    }
}