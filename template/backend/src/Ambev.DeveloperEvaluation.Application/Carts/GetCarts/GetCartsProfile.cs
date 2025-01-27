using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCarts
{
    public class GetCartsProfile : Profile
    {
        public GetCartsProfile()
        {
            CreateMap<List<Cart>, GetCartsResult>()
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src)); 
        }
    }
}
