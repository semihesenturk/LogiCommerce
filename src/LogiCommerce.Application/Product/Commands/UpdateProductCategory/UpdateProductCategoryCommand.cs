using LogiCommerce.SharedKernel.BaseClasses;
using MediatR;

namespace LogiCommerce.Application.Product.Commands.UpdateProductCategory;

public class UpdateProductCategoryCommand : IRequest<BaseServiceResponse<bool>>
{
    public Guid ProductId { get; set; }
    public Guid NewCategoryId { get; set; }
}