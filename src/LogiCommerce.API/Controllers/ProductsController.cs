using LogiCommerce.Application.Product.Commands.CreateProduct;
using LogiCommerce.Application.Product.Commands.DeleteProduct;
using LogiCommerce.Application.Product.Commands.SetProductLiveStatus;
using LogiCommerce.Application.Product.Commands.UpdateProduct;
using LogiCommerce.Application.Product.Commands.UpdateProductCategory;
using LogiCommerce.Application.Product.Queries.GetProductById;
using LogiCommerce.Application.Product.Queries.GetProductsByKeywordOrMinMaxStock;
using LogiCommerce.SharedKernel.BaseClasses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LogiCommerce.API.Controllers;

public class ProductsController(IMediator mediator) : CustomBaseController
{
    [HttpGet]
    public async Task<IActionResult> GetProducts([FromQuery] string? keyword, [FromQuery] int? minStock,
        [FromQuery] int? maxStock)
    {
        var result = await mediator.Send(new GetProductsQuery(keyword, minStock, maxStock));
        return CreateActionResultInstance(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(Guid id, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new GetProductByIdQuery { Id = id }, cancellationToken);
        return CreateActionResultInstance(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request, cancellationToken);
        return CreateActionResultInstance(result);
    }

    [HttpPut("{productId}")]
    public async Task<IActionResult> UpdateProduct(Guid productId, [FromBody] UpdateProductCommand command,
        CancellationToken cancellationToken)
    {
        if (productId != command.ProductId)
            return BadRequest("Product ID in the URL does not match the body.");

        var result = await mediator.Send(command, cancellationToken);
        return CreateActionResultInstance(result);
    }
    
    [HttpPut("{id}/category")]
    public async Task<IActionResult> UpdateProductCategory(Guid id, [FromBody] UpdateProductCategoryCommand command, CancellationToken cancellationToken)
    {
        if (id != command.ProductId)
            return BadRequest("Product ID mismatch");

        var result = await mediator.Send(command, cancellationToken);
        return CreateActionResultInstance(result);
    }

    [HttpPut("{productId}/live")]
    public async Task<IActionResult> SetProductLiveStatus(Guid productId, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new SetProductLiveStatusCommand { ProductId = productId }, cancellationToken);
        return CreateActionResultInstance(result);
    }

    [HttpDelete("{productId}")]
    public async Task<IActionResult> DeleteProduct(Guid productId, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new DeleteProductCommand { ProductId = productId }, cancellationToken);
        return CreateActionResultInstance(result);
    }
}