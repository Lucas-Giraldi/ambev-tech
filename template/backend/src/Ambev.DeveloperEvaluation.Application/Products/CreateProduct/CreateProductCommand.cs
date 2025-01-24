using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProducts;

/// <summary>
/// Command to add a new product.
/// </summary>
public class CreateProductCommand : IRequest<CreateProductResult>
{
    /// <summary>
    /// The title of the product.
    /// Must not be null or empty.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// The price of the product.
    /// Must be a positive decimal number.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// The description of the product.
    /// Must not be null or empty.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// The category of the product.
    /// Must not be null or empty.
    /// </summary>
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// The image URL of the product.
    /// Must not be null or empty.
    /// </summary>
    public string Image { get; set; } = string.Empty;

    /// <summary>
    /// The average rating of the product.
    /// Must be a decimal between 0 and 5.
    /// </summary>
    public decimal? Rate { get; set; }

    /// <summary>
    /// The total count of ratings for the product.
    /// Must be a non-negative integer.
    /// </summary>
    public int? RatingCount { get; set; }
}
