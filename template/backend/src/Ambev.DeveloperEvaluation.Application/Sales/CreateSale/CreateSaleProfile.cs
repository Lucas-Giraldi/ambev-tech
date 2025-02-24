using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleProfile : Profile
{
    public CreateSaleProfile()
    {
        CreateMap<CreateSaleCommand, Domain.Entities.Sales>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
            .ForMember(dest => dest.IsCanceled, opt => opt.MapFrom(src => false))
            .ForMember(dest => dest.SaleCreate, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.CustomerName))
            .ForMember(dest => dest.Items, opt => opt.Ignore())
            .ReverseMap();

        CreateMap<CartItem, SalesItem>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.Discount, opt => opt.Ignore());


        CreateMap<Domain.Entities.Sales, CreateSaleResult>();

        CreateMap<SalesItem, CreateSaleItemResult>()
            .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Product.Price));

    }
}
