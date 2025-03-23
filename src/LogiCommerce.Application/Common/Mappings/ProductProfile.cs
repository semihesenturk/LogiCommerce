using AutoMapper;
using LogiCommerce.Application.Product.Queries.GetProductsByKeyword;

namespace LogiCommerce.Application.Common.Mappings;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Domain.AggregateModels.ProductAggregate.Product, GetProductsByKeywordQueryDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
    }
}