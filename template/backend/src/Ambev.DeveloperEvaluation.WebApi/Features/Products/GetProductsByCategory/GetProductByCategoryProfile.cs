using Ambev.DeveloperEvaluation.Application.Products.CreateProducts;
using Ambev.DeveloperEvaluation.Application.Products.GetProductByCategory;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProductsByCategory
{
    public class GetProductByCategoryProfile : Profile
    {
        public GetProductByCategoryProfile()
        {


            CreateMap<string, GetProductByCategoryCommand>()
                .ForMember(src => src.Category, opt => opt.MapFrom(dest => dest));

            CreateMap<GetProductByCategoryResult, GetProductByCategoryResponse>()
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(src =>
                    new GetProductByCategoryRating
                    {
                        Rate = src.RatingRate,
                        Count = src.RatingCount
                    }));
        }
    }
}
