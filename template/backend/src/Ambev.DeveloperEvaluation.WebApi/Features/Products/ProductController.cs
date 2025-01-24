using Ambev.DeveloperEvaluation.Application.Products.CreateProducts;
using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using Ambev.DeveloperEvaluation.Application.Products.GetProducts;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProducts;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products;

[ApiController]
[Route("api/[controller]")]
public class ProductController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;


    /// <summary>
    /// Initializes a new instance of AuthController
    /// </summary>
    /// <param name="mediator">The mediator instance</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public ProductController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// GET Products
    /// </summary>
    /// <param name="request">The product request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>list of products with order </returns>
    [HttpGet]
    [ProducesResponseType(typeof(ApiResponseWithData<GetProductResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Products([FromQuery] GetProductSRequest request, CancellationToken cancellationToken)
    {
        var validator = new GetProductsRequestValidator();

        var validatorResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validatorResult.IsValid)
            return BadRequest(validatorResult.Errors);

        var command = _mapper.Map<GetProductsCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponseWithData<GetProductResponse>
        {
            Success = true,
            Message = "Get products successfully",
            Data = _mapper.Map<GetProductResponse>(response),
        });
    }

    /// <summary>
    /// POST Products
    /// </summary>
    /// <param name="request">The create product request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>create product </returns>
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateProductResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Products([FromBody] CreateProductRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateProductRequestValidator();

        var validatorResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validatorResult.IsValid)
            return BadRequest(validatorResult.Errors);

        var command = _mapper.Map<CreateProductCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponseWithData<CreateProductResponse>
        {
            Success = true,
            Message = "Get products successfully",
            Data = _mapper.Map<CreateProductResponse>(response),
        });
    }
    /// <summary>
    /// GET Product
    /// </summary>
    /// <param name="id">Id of product</param>
    /// <returns>GET product using Id</returns>
    [HttpGet("/products/")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetProductResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Products([FromQuery] int id, CancellationToken cancellationToken)
    {
        var validator = new GetProductRequestValidator();

        var validatorResult = await validator.ValidateAsync(id, cancellationToken);

        if (!validatorResult.IsValid)
            return BadRequest(validatorResult.Errors); 

        var command = _mapper.Map<GetProductCommand>(id);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponseWithData<GetProductResponse>
        {
            Success = true,
            Message = "Get products successfully",
            Data = _mapper.Map<GetProductResponse>(response),
        });
    }

}
