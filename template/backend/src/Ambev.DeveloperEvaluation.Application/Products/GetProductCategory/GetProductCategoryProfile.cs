using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProductCategory
{
    public class GetProductCategoryProfile : Profile
    {
        public GetProductCategoryProfile()
        {
            CreateMap<List<string>, GetProductCategoryResult>()
                .ForMember(dest => dest.Categories, src => src.MapFrom(str => str));
        }
    }
}
