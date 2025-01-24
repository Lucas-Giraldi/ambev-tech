using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct
{
    public class GetProductProfile : Profile
    {

        public GetProductProfile()
        {
            CreateMap<int, GetProductCommand>()
           .ConstructUsing(id => new GetProductCommand(id));

            CreateMap<GetProductResult, GetProductResponse>()
          .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => new RatingResponse
          {
              Rate = src.Rate,
              Count = src.RatingCount
          }));
        }
    }
}
