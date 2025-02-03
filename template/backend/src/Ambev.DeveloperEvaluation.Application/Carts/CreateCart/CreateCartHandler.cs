using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart
{
    public class CreateCartHandler : IRequestHandler<CreateCartCommand, CreateCartResult>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public CreateCartHandler(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public async Task<CreateCartResult> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {


            var cart = await _cartRepository.CreateCart(new Domain.Entities.Cart
            {
                Date = request.Date,
                UserId = request.UserId,
                Items = request.Products
            });

            return _mapper.Map<CreateCartResult>(cart); 
        }
    }
}
