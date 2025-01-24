using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Products.CreateProducts;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IRatingRepository _ratingRepository;
        private readonly IMapper _mapper;

        public CreateProductHandler(IProductsRepository productsRepository, IRatingRepository ratingRepository, IMapper mapper)
        {
            _productsRepository = productsRepository;
            _ratingRepository = ratingRepository;
            _mapper = mapper;
        }

        public async Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var responseProduct = await _productsRepository.Create(new Domain.Entities.Product
            {
                Category = request.Category,
                Description = request.Description,
                Image = request.Image,
                Price = request.Price,
                Title = request.Title
            });
            ProductRating? responseRating = null;

            if (request.Rate != null && request.RatingCount != null)
            {
                responseRating = await _ratingRepository.Create(new ProductRating
                {
                    Count = request.RatingCount.Value,
                    Rate = request.Rate.Value,
                    ProductId = responseProduct.Id
                });
            }

            var result = _mapper.Map<CreateProductResult>(responseProduct);

            if (responseRating != null)
            {
                _mapper.Map(responseRating, result);
            }
            return result;
        }
    }
}
