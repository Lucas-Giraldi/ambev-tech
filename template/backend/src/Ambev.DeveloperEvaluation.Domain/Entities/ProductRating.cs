using Ambev.DeveloperEvaluation.Domain.Common;

using Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents the rating for a product, including the rating score and the number of ratings received.
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class ProductRating : BaseEntity
{
    /// <summary>
    /// Gets or sets the rating score for the product.
    /// This value represents the average rating score of the product (e.g., 4.5).
    /// It should be a decimal value.
    /// </summary>
    public decimal Rate { get; set; }

    /// <summary>
    /// Gets or sets the total number of ratings the product has received.
    /// This value should reflect the count of individual ratings for the product.
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// Gets or sets the foreign key for the associated product.
    /// This links the rating to a specific product in the system.
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// Navigation property to the associated product.
    /// </summary>

    //POO
    public Product Product { get; set; } = null!;
}
