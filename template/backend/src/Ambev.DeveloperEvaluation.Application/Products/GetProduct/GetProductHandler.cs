using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct
{
    public class GetProductHandler : IRequestHandler<GetProductCommand, GetProductResult>
    {

        private readonly IMapper _mapper;
        private readonly IProductsRepository _productsRepository;

        public GetProductHandler(IMapper mapper, IProductsRepository productsRepository)
        {
            _mapper = mapper;
            _productsRepository = productsRepository;
        }

        public async Task<GetProductResult> Handle(GetProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productsRepository.GetById(request.Id);

            return _mapper.Map<GetProductResult>(product);
        }
    }
}
