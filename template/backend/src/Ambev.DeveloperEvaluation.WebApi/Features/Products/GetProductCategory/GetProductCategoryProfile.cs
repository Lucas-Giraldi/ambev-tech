using Ambev.DeveloperEvaluation.Application.Products.GetProductCategory;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProductCategory
{
    public class GetProductCategoryProfile : Profile
    {
        public GetProductCategoryProfile()
        {
            CreateMap<GetProductCategoryResult, GetProductCategoryResponse>()
                .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Categories));
        }
    }
}
