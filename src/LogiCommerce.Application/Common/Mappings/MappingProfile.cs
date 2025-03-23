using AutoMapper;
using LogiCommerce.Application.Category.Queries.GetCategories;
using LogiCommerce.Application.Category.Queries.GetCategoryProducts;
using LogiCommerce.Application.Product.Commands.UpdateProduct;
using LogiCommerce.Application.Product.Queries.GetProductsByKeywordOrMinMaxStock;

namespace LogiCommerce.Application.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Domain.AggregateModels.ProductAggregate.Product, GetProductsQueryDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.IsLive, opt => opt.MapFrom(src => src.StockQuantity >= src.Category.MinStockLevel));

        CreateMap<Domain.AggregateModels.CategoryAggregate.Category, GetCategoriesQueryDto>()
            .ReverseMap();
        
        CreateMap<Domain.AggregateModels.ProductAggregate.Product, ProductDto>();
        
        CreateMap<Domain.AggregateModels.CategoryAggregate.Category, GetCategoryWithProductsQueryDto>();
        CreateMap<Domain.AggregateModels.ProductAggregate.Product, GetCategoryWithProductsProductDto>();
        CreateMap<Domain.AggregateModels.ProductAggregate.Product, UpdateProductCommandDto>();
    }
}