using LogiCommerce.SharedKernel.BaseClasses;
using MediatR;

namespace LogiCommerce.Application.Product.Commands.UpdateProduct;

public class UpdateProductCommand : IRequest<BaseServiceResponse<UpdateProductCommandDto>>
{
    public Guid ProductId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int StockQuantity { get; set; }
}