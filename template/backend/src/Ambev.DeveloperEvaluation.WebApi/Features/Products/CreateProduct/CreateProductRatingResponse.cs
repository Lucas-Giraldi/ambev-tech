namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct
{
    /// <summary>
    /// Represents the rating details in the response for a product.
    /// </summary>
    public class ProductRatingResponse
    {
        /// <summary>
        /// The average rating of the product.
        /// </summary>
        public decimal Rate { get; set; }

        /// <summary>
        /// The total count of ratings for the product.
        /// </summary>
        public int Count { get; set; }
    }
}
