using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.DeleteProduct
{
    public class DeleteProductProfile : Profile
    {

        public DeleteProductProfile()
        {
            CreateMap<string, DeleteProductResult>()
                .ForMember(dest => dest.Message, str => str.MapFrom(src => src));
        }
    }
}
