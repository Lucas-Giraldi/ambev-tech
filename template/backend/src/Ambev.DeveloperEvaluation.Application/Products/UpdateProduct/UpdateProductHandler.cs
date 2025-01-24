using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, UpdateProductResult>
    {

        private readonly IProductsRepository _productsRepository;
        private readonly IMapper _mapper;
        private readonly IRatingRepository _ratingRepository;

        public UpdateProductHandler(IProductsRepository productsRepository, IMapper mapper, IRatingRepository ratingRepository)
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
            _ratingRepository = ratingRepository;
        }

        async Task<UpdateProductResult> IRequestHandler<UpdateProductCommand, UpdateProductResult>.Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {

            var productMapper = _mapper.Map<Product>(request);
            var result = await _productsRepository.UpdateProduct(request.Id, productMapper);

            if (result.Rating == null && request.RatingCount != null && request.Rate != null)
            {
                var rating = await _ratingRepository.Create(new ProductRating
                {
                    Count = request.RatingCount.Value,
                    Rate = request.Rate.Value,
                    ProductId = request.Id
                });

                result.Rating = rating;
            }
            return _mapper.Map<UpdateProductResult>(result);

        }
    }
}
