using LogiCommerce.SharedKernel.BaseClasses;
using MediatR;

namespace LogiCommerce.Application.Category.Commands.CreateCategory;

public class CreateCategoryCommand : IRequest<BaseServiceResponse<CreateCategoryCommandDto>>
{
    public string Name { get; set; }

    public int MinStockLevel { get; set; } 
}