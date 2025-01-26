using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProductByCategory
{
    public class GetProductByCategoryProfile : Profile
    {

        public GetProductByCategoryProfile()
        {
            CreateMap<Product, GetProductByCategoryResult>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image))
                .ForMember(dest => dest.RatingRate, opt => opt.MapFrom(src => src.Rating != null ? src.Rating.Rate : (decimal?)null))
                .ForMember(dest => dest.RatingCount, opt => opt.MapFrom(src => src.Rating != null ? src.Rating.Count : (int?)null));
        }
    }
}
