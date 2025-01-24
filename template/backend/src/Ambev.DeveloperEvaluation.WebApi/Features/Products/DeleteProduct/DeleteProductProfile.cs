using Ambev.DeveloperEvaluation.Application.Products.DeleteProduct;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.DeleteProduct
{
    public class DeleteProductProfile : Profile
    {
        public DeleteProductProfile()
        {
            CreateMap<int, DeleteProductCommand>()
                .ForMember(dpr => dpr.Id, dpc => dpc.MapFrom(src => src));

            CreateMap<DeleteProductResult, DeleteProductResponse>()
                .ForMember(dpre => dpre.Message, dprt => dprt.MapFrom(src => src.Message));
        }
    }
}
