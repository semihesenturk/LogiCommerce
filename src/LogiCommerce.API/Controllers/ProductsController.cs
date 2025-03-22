using LogiCommerce.Application.Product.Commands;
using LogiCommerce.SharedKernel.BaseClasses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LogiCommerce.API.Controllers;

public class ProductsController(IMediator mediator) : CustomBaseController
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateProductCommand request,
        CancellationToken cancellationToken = default(CancellationToken))
    {
        var result = await mediator.Send(request, cancellationToken);
        return CreateActionResultInstance(result);
    }
}