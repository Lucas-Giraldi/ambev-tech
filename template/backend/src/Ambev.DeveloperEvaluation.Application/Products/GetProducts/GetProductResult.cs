using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProducts
{
    public sealed class GetProductResult
    {
        public GetProductResult(int totalItems, int currentPage, int totalPages)
        {
            TotalItems = totalItems;
            CurrentPage = currentPage;
            TotalPages = totalPages;
        }

        /// <summary>
        /// List of products
        /// </summary>
        public List<Product> Data { get; set; }

        /// <summary>
        /// Get the count of products
        /// </summary>
        public int TotalItems { get; set; }

        /// <summary>
        /// Get the current page
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// Get the total pages
        /// </summary>
        public int TotalPages { get; set; }
    }
}
