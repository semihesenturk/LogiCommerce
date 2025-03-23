using LogiCommerce.SharedKernel.BaseClasses;
using MediatR;

namespace LogiCommerce.Application.Product.Commands.SetProductLiveStatus;

public class SetProductLiveStatusCommand : IRequest<BaseServiceResponse<bool>>
{
    public Guid ProductId { get; set; }
}