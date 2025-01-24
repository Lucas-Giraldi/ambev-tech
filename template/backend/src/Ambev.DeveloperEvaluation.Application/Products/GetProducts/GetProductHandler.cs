using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProducts
{
    public class GetProductHandler : IRequestHandler<GetProductsCommand, GetProductResult>
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IMapper _mapper;

        public GetProductHandler(IProductsRepository productsRepository, IMapper mapper)
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
        }

        public async Task<GetProductResult> Handle(GetProductsCommand request, CancellationToken cancellationToken)
        {
            var totalItems = await _productsRepository.GetTotalItems();

            var result = new GetProductResult(totalItems, request.Page.Value, (int)Math.Ceiling((double)totalItems / request.Size.Value));
            result.Data  = await _productsRepository.GetPaginatedAndOrderedProducts(request.Page.Value, request.Size.Value, request.Order);
            
            return result;
        }
    }
}
