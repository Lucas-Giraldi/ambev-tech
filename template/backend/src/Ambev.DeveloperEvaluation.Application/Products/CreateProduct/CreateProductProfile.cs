using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Products.CreateProducts;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct
{
    public class CreateProductProfile : Profile
    {

        public CreateProductProfile()
        {
            // Mapear Product para CreateProductResult
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
        }

    }
}
