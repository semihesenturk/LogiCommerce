using LogiCommerce.Application.Product.Commands.CreateProduct;
using LogiCommerce.Application.Product.Commands.DeleteProduct;
using LogiCommerce.Application.Product.Queries.GetProductsByKeywordOrMinMaxStock;
using LogiCommerce.SharedKernel.BaseClasses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LogiCommerce.API.Controllers;

public class ProductsController(IMediator mediator) : CustomBaseController
{

    [HttpGet]
    public async Task<IActionResult> GetProducts([FromQuery] string? keyword, [FromQuery] int? minStock, [FromQuery] int? maxStock)
    {
        var result = await mediator.Send(new GetProductsQuery(keyword, minStock, maxStock));
        return CreateActionResultInstance(result);
    }
  
 
    [HttpPost]
    public async Task<IActionResult> Create(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request, cancellationToken);
        return CreateActionResultInstance(result);
    }
    
    [HttpDelete("{productId}")]
    public async Task<IActionResult> DeleteProduct(Guid productId, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new DeleteProductCommand{ProductId = productId}, cancellationToken);
        return CreateActionResultInstance(result);
    }
}