using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProducts;

public sealed class GetProductsResponse
{

    /// <summary>
    /// List of products
    /// </summary>
    public List<Product> Data { get; set; }

    /// <summary>
    /// Get the count of products
    /// </summary>
    public int TotalItems { get; set; }

    /// <summary>
    /// Get the current page
    /// </summary>
    public int CurrentPage { get; set; }

    /// <summary>
    /// Get the total pages
    /// </summary>
    public int TotalPages { get; set; }
}
