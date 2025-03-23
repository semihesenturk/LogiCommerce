using LogiCommerce.SharedKernel.BaseClasses;
using MediatR;

namespace LogiCommerce.Application.Product.Queries.GetProductById;

public class GetProductByIdQuery : IRequest<BaseServiceResponse<GetProductByIdQueryDto>>
{
    public Guid Id { get; set; }
}