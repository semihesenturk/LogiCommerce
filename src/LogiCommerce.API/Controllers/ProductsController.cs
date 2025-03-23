using LogiCommerce.Application.Product.Commands.CreateProduct;
using LogiCommerce.Application.Product.Queries.GetProductsByKeyword;
using LogiCommerce.SharedKernel.BaseClasses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LogiCommerce.API.Controllers;

public class ProductsController(IMediator mediator) : CustomBaseController
{

    [HttpGet("keyword")]
    public async Task<IActionResult> GetProductsByKeyword(string keyword, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetProductsByKeywordQuery{Keyword = keyword}, cancellationToken);
        return CreateActionResultInstance(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request, cancellationToken);
        return CreateActionResultInstance(result);
    }
}