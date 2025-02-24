using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.ModifySale;

public class ModifySaleProfile : Profile
{
    public ModifySaleProfile()
    {
        CreateMap<CartItem, SalesItem>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.Discount, opt => opt.Ignore());

        CreateMap<Domain.Entities.Sales, ModifySaleResult>();

        CreateMap<SalesItem, ModifySaleItemResult>()
            .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Product.Price));
    }
}
