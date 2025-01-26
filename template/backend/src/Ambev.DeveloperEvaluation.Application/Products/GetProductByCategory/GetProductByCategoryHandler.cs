using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProductByCategory
{
    public class GetProductByCategoryHandler : IRequestHandler<GetProductByCategoryCommand, List<GetProductByCategoryResult>>
    {
        private readonly IProductsRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductByCategoryHandler(IProductsRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<GetProductByCategoryResult>> Handle(GetProductByCategoryCommand request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetProductByCategory(request.Category);

            return _mapper.Map<List<GetProductByCategoryResult>>(products);
        }
    }
}
