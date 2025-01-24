using Ambev.DeveloperEvaluation.Application.Products.CreateProducts;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.CreateUser;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

public class CreateProductProfile : Profile
{
    public CreateProductProfile()
    {
        CreateMap<Product, CreateProductResult>()
            .ForMember(dest => dest.Rate, opt => opt.Ignore())
            .ForMember(dest => dest.RatingCount, opt => opt.Ignore());

        CreateMap<ProductRating, CreateProductResult>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Title, opt => opt.Ignore())
            .ForMember(dest => dest.Price, opt => opt.Ignore())
            .ForMember(dest => dest.Description, opt => opt.Ignore())
            .ForMember(dest => dest.Category, opt => opt.Ignore())
            .ForMember(dest => dest.Image, opt => opt.Ignore());

        CreateMap<CreateProductResult, CreateProductResponse>()
            .ForMember(dest => dest.Rating, opt => opt.MapFrom(src =>
                src.Rate.HasValue && src.RatingCount.HasValue
                    ? new ProductRatingResponse
                    {
                        Rate = src.Rate.Value,
                        Count = src.RatingCount.Value
                    }
                    : null));

        CreateMap<CreateProductRequest, CreateProductCommand>();
    }
}
