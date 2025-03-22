using LogiCommerce.SharedKernel.BaseClasses;
using MediatR;

namespace LogiCommerce.Application.Product.Commands;

public class CreateProductCommand : IRequest<BaseServiceResponse<CreateProductCommandDto>>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int StockQuantity { get; set; }
    public int CategoryId { get; set; }
}