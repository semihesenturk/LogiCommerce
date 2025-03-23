using LogiCommerce.SharedKernel.BaseClasses;
using MediatR;

namespace LogiCommerce.Application.Category.Queries.GetCategoryProducts;

public class GetCategoryWithProductsQuery : IRequest<BaseServiceResponse<GetCategoryWithProductsQueryDto>>
{
    public Guid CategoryId { get; }

    public GetCategoryWithProductsQuery(Guid categoryId)
    {
        CategoryId = categoryId;
    }
}