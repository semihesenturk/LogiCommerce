using AutoMapper;
using LogiCommerce.Domain.AggregateModels.CategoryAggregate;
using LogiCommerce.Domain.AggregateModels.CategoryAggregate.Specification;
using LogiCommerce.SharedKernel.BaseClasses;
using MediatR;

namespace LogiCommerce.Application.Category.Queries.GetCategories;

public class GetCategoriesQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
    : IRequestHandler<GetCategoriesQuery, BaseServiceResponse<List<GetCategoriesQueryDto>>>
{
    public async Task<BaseServiceResponse<List<GetCategoriesQueryDto>>> Handle(GetCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        var getCategoriesSpecification = new GetAllCategoriesSpecification();
        var categoryList = await categoryRepository.ListAsync(getCategoriesSpecification, cancellationToken);
        var mappedCategories = mapper.Map<List<GetCategoriesQueryDto>>(categoryList);

        return BaseServiceResponse<List<GetCategoriesQueryDto>>.Success(mappedCategories, 200);
    }
}