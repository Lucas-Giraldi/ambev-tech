using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using Ambev.DeveloperEvaluation.Application.Carts.DeleteCart;
using Ambev.DeveloperEvaluation.Application.Carts.GetCartById;
using Ambev.DeveloperEvaluation.Application.Carts.GetCarts;
using Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;
using Ambev.DeveloperEvaluation.Application.Products.GetProducts;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.DeleteCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCartById;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCarts;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProducts;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;


        /// <summary>
        /// Initializes a new instance of AuthController
        /// </summary>
        /// <param name="mediator">The mediator instance</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public CartController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Get cart
        /// </summary>
        /// <param name="request">Request carts</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns> List cart </returns>
        [HttpGet("/cart")]
        [ProducesResponseType(typeof(ApiResponseWithData<GetCartsResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetCarts([FromQuery] GetCartsRequest request, CancellationToken cancellationToken)
        {
            var validator = new GetCartsRequestValidator();

            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
                return BadRequest(validatorResult.Errors);

            var command = _mapper.Map<GetCartsCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(_mapper.Map<GetCartsResponse>(response));
        }

        /// <summary>
        /// Get cart
        /// </summary>
        /// <param name="request">Request carts</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns> List cart </returns>
        [HttpGet("cart/{id}")]
        [ProducesResponseType(typeof(ApiResponseWithData<GetCartByIdResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetCart([FromRoute] string id, CancellationToken cancellationToken)
        {
            var validator = new GetCartByIdRequestValidator();

            var validatorResult = await validator.ValidateAsync(id, cancellationToken);

            if (!validatorResult.IsValid)
                return BadRequest(validatorResult.Errors);

            var command = _mapper.Map<GetCartByIdCommand>(id);
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(_mapper.Map<GetCartByIdResponse>(response));
        }

        /// <summary>
        /// Create cart
        /// </summary>
        /// <param name="request">The product request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns> New cart </returns>
        [HttpPost("/cart")]
        [ProducesResponseType(typeof(ApiResponseWithData<CreateCartResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCart([FromBody] CreateCartRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateCartRequestValidator();

            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
                return BadRequest(validatorResult.Errors);

            var command = _mapper.Map<CreateCartCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            return OkWithData(response);
        }

        /// <summary>
        /// Create cart
        /// </summary>
        /// <param name="request">The product request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns> New cart </returns>
        [HttpPut("/cart/{id}")]
        [ProducesResponseType(typeof(ApiResponseWithData<UpdateCartResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateCart([FromRoute] string id, [FromBody] UpdateCartRequest request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCartRequestValidator();
            request.Id = id;
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
                return BadRequest(validatorResult.Errors);

            var command = _mapper.Map<UpdateCartCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            return OkWithData(response);
        }

        /// <summary>
        /// Create cart
        /// </summary>
        /// <param name="request">The product request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns> New cart </returns>
        [HttpDelete("/cart/{id}")]
        [ProducesResponseType(typeof(ApiResponseWithData<DeleteCartResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteCart([FromRoute] string id, CancellationToken cancellationToken)
        {
            var validator = new DeleteCartRequestValidator();
            var validatorResult = await validator.ValidateAsync(id, cancellationToken);

            if (!validatorResult.IsValid)
                return BadRequest(validatorResult.Errors);

            var command = _mapper.Map<DeleteCartCommand>(id);
            try
            {
                await _mediator.Send(command, cancellationToken);
                return Ok("Delete success!");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

        }

    }
}
