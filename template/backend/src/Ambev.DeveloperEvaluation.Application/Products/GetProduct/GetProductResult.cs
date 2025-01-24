namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct
{
    public class GetProductResult
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
        /// The average rate of the product.
        /// </summary>
        public decimal? Rate { get; set; }

        /// <summary>
        /// The total count of ratings for the product.
        /// </summary>
        public int? RatingCount { get; set; }
    }
}

