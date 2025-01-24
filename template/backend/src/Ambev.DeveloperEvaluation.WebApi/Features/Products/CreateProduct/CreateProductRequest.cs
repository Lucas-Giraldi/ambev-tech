namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct
{
    /// <summary>
    /// Represents the request to create a new product.
    /// This includes all the necessary fields to define a product and its rating.
    /// </summary>
    public class CreateProductRequest
    {
        /// <summary>
        /// Title of the product.
        /// Must be a non-empty string.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Price of the product.
        /// Must be a decimal number greater than or equal to 0.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Description of the product.
        /// Provides detailed information about the product.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Category of the product.
        /// Indicates the classification or grouping of the product.
        /// </summary>
        public string Category { get; set; } = string.Empty;

        /// <summary>
        /// Image URL for the product.
        /// Must be a valid URL or path to the image.
        /// </summary>
        public string Image { get; set; } = string.Empty;

        /// <summary>
        /// Rating for the product.
        /// Includes the average rate and the count of ratings.
        /// </summary>
        public CreateProductRatingRequest Rating { get; set; } = new CreateProductRatingRequest();
    }

}
