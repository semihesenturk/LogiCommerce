using AutoMapper;
using LogiCommerce.Application.Category.Queries.GetCategories;
using LogiCommerce.Application.Product.Queries.GetProductsByKeywordOrMinMaxStock;

namespace LogiCommerce.Application.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Domain.AggregateModels.ProductAggregate.Product, GetProductsQueryDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

        CreateMap<Domain.AggregateModels.CategoryAggregate.Category, GetCategoriesQueryDto>()
            .ReverseMap();
        
        CreateMap<Domain.AggregateModels.ProductAggregate.Product, ProductDto>();
    }
}