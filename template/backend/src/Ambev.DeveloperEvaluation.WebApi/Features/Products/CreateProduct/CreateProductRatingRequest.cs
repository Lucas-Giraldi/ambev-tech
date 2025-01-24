namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct
{
    /// <summary>
    /// Represents the rating details for a product.
    /// </summary>
    public class CreateProductRatingRequest
    {
        /// <summary>
        /// Average rating of the product.
        /// Must be a decimal number between 0 and 5.
        /// </summary>
        public decimal Rate { get; set; }

        /// <summary>
        /// Number of ratings the product has received.
        /// Must be a non-negative integer.
        /// </summary>
        public int Count { get; set; }
    }
}
