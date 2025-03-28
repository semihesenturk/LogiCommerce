using LogiCommerce.Application.Category.Commands.CreateCategory;
using LogiCommerce.Application.Category.Queries.GetCategories;
using LogiCommerce.Application.Category.Queries.GetCategoryProducts;
using LogiCommerce.SharedKernel.BaseClasses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LogiCommerce.API.Controllers;

public class CategoriesController(IMediator mediator) : CustomBaseController
{
    [HttpGet]
    public async Task<IActionResult> GetCategories(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetCategoriesQuery(), cancellationToken);
        return CreateActionResultInstance(result);
    }
    
    [HttpGet("{categoryId}/products")]
    public async Task<IActionResult> GetCategoryWithProducts(Guid categoryId, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetCategoryWithProductsQuery(categoryId), cancellationToken);
        return CreateActionResultInstance(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCategoryCommand request,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request, cancellationToken);
        return CreateActionResultInstance(result);
    }
}