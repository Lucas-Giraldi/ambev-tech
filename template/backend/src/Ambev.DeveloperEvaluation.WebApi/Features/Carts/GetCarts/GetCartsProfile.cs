using Ambev.DeveloperEvaluation.Application.Carts.GetCarts;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCarts
{
    public class GetCartsProfile : Profile
    {
        public GetCartsProfile()
        {
            CreateMap<GetCartsRequest, GetCartsCommand>();
            CreateMap<GetCartsResult, GetCartsResponse>();
        }
    }
}
