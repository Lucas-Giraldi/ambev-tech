using Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct
{
    public class UpdateProductProfile : Profile
    {

        public UpdateProductProfile()
        {
            CreateMap<UpdateProductRequest, UpdateProductCommand>()
                    .ForMember(dest => dest.Rate, opt => opt.MapFrom(src => src.Rating.Rate))
                    .ForMember(dest => dest.RatingCount, opt => opt.MapFrom(src => src.Rating.Count))
                    .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                    .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                    .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                    .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image));


            CreateMap<UpdateProductResult, UpdateProductResponse>()
                 .ForMember(dest => dest.Rating, opt => opt.MapFrom(src =>
                     src.Rate.HasValue && src.RatingCount.HasValue
                         ? new UpdateProductRating
                         {
                             Rate = src.Rate.Value,
                             Count = src.RatingCount.Value
                         }
                         : null));


        }
    }
}
