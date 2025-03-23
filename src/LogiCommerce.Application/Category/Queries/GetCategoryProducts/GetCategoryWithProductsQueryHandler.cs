using AutoMapper;
using LogiCommerce.Domain.AggregateModels.CategoryAggregate;
using LogiCommerce.Domain.AggregateModels.CategoryAggregate.Specification;
using LogiCommerce.SharedKernel.BaseClasses;
using MediatR;

namespace LogiCommerce.Application.Category.Queries.GetCategoryProducts;

public class GetCategoryWithProductsQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
    : IRequestHandler<GetCategoryWithProductsQuery, BaseServiceResponse<GetCategoryWithProductsQueryDto>>
{
    public async Task<BaseServiceResponse<GetCategoryWithProductsQueryDto>> Handle(GetCategoryWithProductsQuery request, CancellationToken cancellationToken)
    {
        var spec = new GetCategoryWithProductsSpecification(request.CategoryId);
        var category = await categoryRepository.FirstOrDefaultAsync(spec, cancellationToken);

        if (category == null)
            return BaseServiceResponse<GetCategoryWithProductsQueryDto>.Fail("Category not found", 404);

        var mappedCategory = mapper.Map<GetCategoryWithProductsQueryDto>(category);

        return BaseServiceResponse<GetCategoryWithProductsQueryDto>.Success(mappedCategory, 200);
    }
}