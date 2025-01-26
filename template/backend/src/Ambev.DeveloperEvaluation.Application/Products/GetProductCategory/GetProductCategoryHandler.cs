using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProductCategory
{
    public class GetProductCategoryHandler : IRequestHandler<GetProductCategoryCommand, GetProductCategoryResult>
    {
        private readonly IProductsRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductCategoryHandler(IProductsRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<GetProductCategoryResult> Handle(GetProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var categories = await _productRepository.GetProductCategories();

            return _mapper.Map<GetProductCategoryResult>(categories);
        }
    }
}
