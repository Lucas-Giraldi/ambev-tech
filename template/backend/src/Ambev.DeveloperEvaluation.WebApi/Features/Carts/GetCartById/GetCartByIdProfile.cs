using Ambev.DeveloperEvaluation.Application.Carts.GetCartById;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCartById
{
    public class GetCartByIdProfile : Profile
    {
        public GetCartByIdProfile()
        {
            CreateMap<GetCartByIdResult, GetCartByIdResponse>();
            CreateMap<string, GetCartByIdCommand>()
                .ForMember(dest => dest.Id, src => src.MapFrom(str => str));
        }
    }
}
