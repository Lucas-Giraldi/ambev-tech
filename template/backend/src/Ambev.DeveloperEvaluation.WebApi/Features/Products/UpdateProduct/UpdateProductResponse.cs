namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct
{
    public class UpdateProductResponse
    {
        /// <summary>
        /// The unique identifier of the product.
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
        /// A detailed description of the product.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The category or classification of the product.
        /// </summary>
        public string Category { get; set; } = string.Empty;

        /// <summary>
        /// The URL or path of the product's image.
        /// </summary>
        public string Image { get; set; } = string.Empty;

        /// <summary>
        /// The average rating of the product.
        /// </summary>
        /// 
        public UpdateProductRating Rating { get; set; }
    }
}
