using LogiCommerce.Application.Category.Commands.CreateCategory;
using LogiCommerce.SharedKernel.BaseClasses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LogiCommerce.API.Controllers;

public class CategoriesController(IMediator mediator) : CustomBaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request, cancellationToken);
        return CreateActionResultInstance(result);
    }
}