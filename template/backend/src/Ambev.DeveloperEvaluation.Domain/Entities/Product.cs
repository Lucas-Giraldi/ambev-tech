using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents a product entity in the system.
    /// Contains all the essential details about a product.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets or sets the unique identifier for the product.
        /// Must be a positive integer.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the product.
        /// Must not be null or empty. Represents the name of the product.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the price of the product.
        /// Must be a positive value.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the description of the product.
        /// Provides detailed information about the product.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the category the product belongs to.
        /// Must not be null or empty.
        /// </summary>
        public string Category { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the URL of the product image.
        /// Must be a valid URL format.
        /// </summary>
        public string Image { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the average rating of the product.
        /// Value should be between 0 and 5.
        /// </summary>
        /// 
        public ProductRating Rating { get; set; }
    }

}
