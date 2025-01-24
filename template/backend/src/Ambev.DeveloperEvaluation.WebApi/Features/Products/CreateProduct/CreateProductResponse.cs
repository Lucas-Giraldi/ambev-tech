namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct
{
    /// <summary>
    /// Represents the response returned after creating a product.
    /// </summary>
    public class CreateProductResponse
    {
        /// <summary>
        /// The unique identifier of the created product.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The title of the product.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// The price of the product.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// The description of the product.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The category of the product.
        /// </summary>
        public string Category { get; set; } = string.Empty;

        /// <summary>
        /// The image URL of the product.
        /// </summary>
        public string Image { get; set; } = string.Empty;

        /// <summary>
        /// The rating details of the product.
        /// </summary>
        public ProductRatingResponse? Rating { get; set; }
    }
}
