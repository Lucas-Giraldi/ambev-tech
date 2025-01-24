﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct
{
    public class UpdateProductProfile : Profile
    {
        public UpdateProductProfile()
        {
            CreateMap<UpdateProductCommand, Product>()
                 .ForMember(dest => dest.Rating, opt => opt.MapFrom(src =>
                     src.Rate.HasValue && src.RatingCount.HasValue
                     ? new ProductRating
                     {
                         Rate = src.Rate.Value,
                         Count = src.RatingCount.Value
                     }
                     : null));


            CreateMap<Product, UpdateProductResult>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
               .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
               .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
               .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
               .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image))
               .ForMember(dest => dest.Rate, opt => opt.MapFrom(src => src.Rating != null ? src.Rating.Rate : (decimal?)null))
               .ForMember(dest => dest.RatingCount, opt => opt.MapFrom(src => src.Rating != null ? src.Rating.Count : (int?)null));
        }

    }
}
