using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct
{
    /// <summary>
    /// Represents the result of updating a product.
    /// </summary>
    public class UpdateProductResult
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
        public decimal? Rate { get; set; }

        /// <summary>
        /// The total number of ratings for the product.
        /// </summary>
        public int? RatingCount { get; set; }
    }

}
