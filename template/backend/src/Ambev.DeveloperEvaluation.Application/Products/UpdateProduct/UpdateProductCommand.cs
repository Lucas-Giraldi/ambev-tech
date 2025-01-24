using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct
{
    /// <summary>
    /// Command to update an existing product.
    /// </summary>
    public class UpdateProductCommand : IRequest<UpdateProductResult>
    {
        /// <summary>
        /// The ID of the product to be updated.
        /// Must be a positive integer.
        /// </summary>
        public int Id { get; set; }

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
}
