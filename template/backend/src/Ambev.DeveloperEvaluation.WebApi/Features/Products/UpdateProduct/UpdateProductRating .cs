namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;

public class UpdateProductRating
{
    /// <summary>
    /// The average rate of the product.
    /// </summary>
    public decimal? Rate { get; set; }

    /// <summary>
    /// The total count of ratings for the product.
    /// </summary>
    public int? Count { get; set; }
}
