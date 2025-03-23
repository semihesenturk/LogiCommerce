using LogiCommerce.SharedKernel.BaseClasses;
using MediatR;

namespace LogiCommerce.Application.Product.Commands.DeleteProduct;

public class DeleteProductCommand : IRequest<BaseServiceResponse<bool>>
{
    public Guid ProductId { get; set; }
}