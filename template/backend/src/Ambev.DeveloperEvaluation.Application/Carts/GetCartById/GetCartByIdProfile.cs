using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCartById
{
    public class GetCartByIdProfile : Profile
    {
        public GetCartByIdProfile()
        {
            CreateMap<Cart, GetCartByIdResult>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
              .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
              .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
              .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Items.Select(item => new CartItem
              {
                  ProductId = item.ProductId,
                  Quantity = item.Quantity
              }).ToList()));
        }
    }
}
