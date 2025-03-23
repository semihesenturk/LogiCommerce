using LogiCommerce.SharedKernel.BaseClasses;
using MediatR;

namespace LogiCommerce.Application.Category.Queries.GetCategories;

public class GetCategoriesQuery : IRequest<BaseServiceResponse<List<GetCategoriesQueryDto>>>
{
    
}