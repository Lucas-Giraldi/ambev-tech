﻿using Ambev.DeveloperEvaluation.Application.Products.CreateProducts;
using Ambev.DeveloperEvaluation.Application.Products.DeleteProduct;
using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using Ambev.DeveloperEvaluation.Application.Products.GetProductByCategory;
using Ambev.DeveloperEvaluation.Application.Products.GetProductCategory;
using Ambev.DeveloperEvaluation.Application.Products.GetProducts;
using Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.DeleteProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProductCategory;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProducts;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProductsByCategory;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;
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
    [HttpGet("/products")]
    [ProducesResponseType(typeof(GetProductResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetProducts([FromQuery] GetProductSRequest request, CancellationToken cancellationToken)
    {
        var validator = new GetProductsRequestValidator();

        var validatorResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validatorResult.IsValid)
            return BadRequest(validatorResult.Errors);

        var command = _mapper.Map<GetProductsCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(_mapper.Map<GetProductsResponse>(response));
    }

    /// <summary>
    /// POST Products
    /// </summary>
    /// <param name="request">The create product request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>create product </returns>
    [HttpPost("/products")]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateProductResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateProductRequestValidator();

        var validatorResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validatorResult.IsValid)
            return BadRequest(validatorResult.Errors);

        var command = _mapper.Map<CreateProductCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return OkWithData(new ApiResponseWithData<CreateProductResponse>
        {
            Success = true,
            Message = "Create products successfully",
            Data = _mapper.Map<CreateProductResponse>(response),
        });
    }
    /// <summary>
    /// GET Product
    /// </summary>
    /// <param name="id">Id of product</param>
    /// <returns>GET product using Id</returns>
    [HttpGet("/products/{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetProductResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetProduct(int id, CancellationToken cancellationToken)
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
            Message = "Get product successfully",
            Data = _mapper.Map<GetProductResponse>(response),
        });
    }

    /// <summary>
    /// PUT Product
    /// </summary>
    /// <param name="id">Id of product</param>
    /// <param name="request">Product body</param>
    /// <returns>Update product using Id</returns>
    [HttpPut("/product/{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<UpdateProductResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] UpdateProductRequest request, CancellationToken cancellationToken)
    {
        if (id <= 0)
        {
            return BadRequest(new ApiResponse
            {
                Success = false,
                Message = "Invalid product ID."
            });
        }

        var validator = new UpdateProductRequestValidator();

        var validatorResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validatorResult.IsValid)
            return BadRequest(validatorResult.Errors);

        var command = _mapper.Map<UpdateProductCommand>(request);
        command.Id = id;

        var response = await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponseWithData<UpdateProductResponse>
        {
            Success = true,
            Message = "Update products successfully",
            Data = _mapper.Map<UpdateProductResponse>(response),
        });
    }

    /// <summary>
    /// DELETE Product
    /// </summary>
    /// <param name="id">Id of product</param>
    /// <returns>Delete product using Id</returns>
    [HttpDelete("/product/{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<DeleteProductResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteProduct([FromRoute] int id, CancellationToken cancellationToken)
    {
        var validator = new DeleteProductRequestValidator();

        var validatorResult = await validator.ValidateAsync(id, cancellationToken);

        if (!validatorResult.IsValid)
            return BadRequest(validatorResult.Errors);

        var command = _mapper.Map<DeleteProductCommand>(id);

        var response = await _mediator.Send(command, cancellationToken);
        return OkWithData(response.Message);
    }

    /// <summary>
    /// GET category Product
    /// </summary>
    /// <returns>Delete product using Id</returns>
    [HttpGet("/product/categories")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetProductCategoryResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetCategoryProduct(CancellationToken cancellationToken)
    {
        var command = new GetProductCategoryCommand();
        var response = await _mediator.Send(command, cancellationToken);

        if (!response.Categories.Any())
        {
            Response.Headers.Add("X-Message", "No content Category");
            return NoContent();
        }

        return Ok(new ApiResponseWithData<GetProductCategoryResponse>
        {
            Success = true,
            Message = "get products categories successfully",
            Data = _mapper.Map<GetProductCategoryResponse>(response),
        });
    }
    /// <summary>
    /// GET category Product
    /// </summary>
    /// <param name="id">Id of product</param>
    /// <returns>Delete product using Id</returns>
    [HttpGet("/product/category/{category}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetProductCategoryResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetProductByCategory([FromRoute] string category, CancellationToken cancellationToken)
    {
        var validator = new GetProductsByCategoryRequestValidator();

        var validatorResult = await validator.ValidateAsync(category);

        if (!validatorResult.IsValid)
            return BadRequest(validatorResult.Errors);

        var command = _mapper.Map<GetProductByCategoryCommand>(category);
        var response = await _mediator.Send(command, cancellationToken);

        if (!response.Any())
        {
            Response.Headers.Add("X-Message", "No content Category");
            return NoContent();
        }

        List<GetProductByCategoryResponse> responseMapper = _mapper.Map<List<GetProductByCategoryResult>, List<GetProductByCategoryResponse>>(response);

        return Ok(new ApiResponseWithData<List<GetProductByCategoryResponse>>
        {
            Success = true,
            Message = "get product category successfully",
            Data = responseMapper,
        });
    }
}
