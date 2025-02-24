using Ambev.DeveloperEvaluation.Application.Sales.ModifySale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.ModifiedSale;

public class ModifySaleProfile : Profile
{
    public ModifySaleProfile()
    {
        CreateMap<ModifySaleRequest, ModifySaleCommand>()
                .ReverseMap();

        CreateMap<ModifySaleResult, ModifySaleResponse>()
            .ReverseMap();
    }
}
