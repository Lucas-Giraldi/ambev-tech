using Ambev.DeveloperEvaluation.Application.Products.GetProducts;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProducts
{
    /// <summary>
    /// AutoMapper profile for get products mappings
    /// </summary>
    public sealed class GetProductsProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetProductsProfile"/> class
        /// </summary>
        public GetProductsProfile()
        {
            CreateMap<GetProductSRequest, GetProductsCommand>();
            CreateMap<GetProductResult, GetProductsResponse>();
        }
    }
}
