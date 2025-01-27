using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCartById
{
    public class GetCartByIdHandler : IRequestHandler<GetCartByIdCommand, GetCartByIdResult>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public GetCartByIdHandler(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }
        public async Task<GetCartByIdResult> Handle(GetCartByIdCommand request, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetCartById(request.Id);

            return _mapper.Map<GetCartByIdResult>(cart);
        }
    }
}
