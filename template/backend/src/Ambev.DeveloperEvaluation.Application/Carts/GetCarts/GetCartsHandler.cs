using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCarts
{
    public class GetCartsHandler : IRequestHandler<GetCartsCommand, GetCartsResult>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public GetCartsHandler(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public async Task<GetCartsResult> Handle(GetCartsCommand request, CancellationToken cancellationToken)
        {
            var carts = await _cartRepository.GetAllCarts(request.Page, request.Size, request.Order);

            var result = _mapper.Map<GetCartsResult>(carts);
            result.TotalItems = carts.Count;
            result.CurrentPage = request.Page;
            result.TotalPages = (int)Math.Ceiling((double)carts.Count / request.Size);

            return result;
        }
    }
}
