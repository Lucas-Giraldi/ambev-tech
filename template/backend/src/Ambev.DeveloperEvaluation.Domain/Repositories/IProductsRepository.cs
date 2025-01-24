using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IProductsRepository
    {
        /// <summary>
        /// Get pagineted products 
        /// </summary>
        /// <param name="page">The current page</param>
        /// <param name="size">Size of page</param>
        /// <param name="order">Order of products</param>
        /// <returns>List of products</returns>
        Task<List<Product>> GetPaginatedAndOrderedProducts(int page, int size, string order);

        /// <summary>
        /// Get the count of products
        /// </summary>
        /// <returns>Total items</returns>
        Task<int> GetTotalItems();

        /// <summary>
        /// Create product
        /// </summary>
        /// <returns>Total items</returns>
        Task<Product> Create(Product product);


        /// <summary>
        /// Create product
        /// </summary>
        /// <returns>Total items</returns>
        Task<Product> GetById(int id);


        /// <summary>
        /// Update product
        /// </summary>
        /// <returns>Total items</returns>
        Task<Product> UpdateProduct(int id, Product product);

        /// <summary>
        /// Delete product
        /// </summary>
        /// <returns>Message delete</returns>
        Task<string> DeleteProduct(int id);
    }
}
