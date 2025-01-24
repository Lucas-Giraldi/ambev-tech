using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    /// <summary>
    /// Implementation of IProductsRepository using Entity Framework Core
    /// </summary>
    public class ProductsRepository : IProductsRepository
    {

        private readonly DefaultContext _context;

        /// <summary>
        /// Initializes a new instance of UserRepository
        /// </summary>
        /// <param name="context">The database context</param>
        public ProductsRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task<Product> Create(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<string> DeleteProduct(int id)
        {
            try
            {
                var product = await _context.Products.FindAsync(id);

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return "Product Delete Success!";
            }
            catch (Exception ex)
            {
                return $"Delete Error : {ex.Message}";
            }
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.Products.Include(p => p.Rating).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Product>> GetPaginatedAndOrderedProducts(int page, int size, string order)
        {
            return await _context.Products
                     .Skip((page - 1) * size)
                     .Take(size).ToListAsync();

        }

        public async Task<int> GetTotalItems()
        {
            return await _context.Products.CountAsync();
        }

        public async Task<Product> UpdateProduct(int id, Product product)
        {
            var existingProduct = await _context.Products
          .Include(p => p.Rating)
          .FirstOrDefaultAsync(p => p.Id == id);

            existingProduct.Title = product.Title;
            existingProduct.Price = product.Price;
            existingProduct.Description = product.Description;
            existingProduct.Category = product.Category;
            existingProduct.Image = product.Image;
            if (existingProduct.Rating != null && product.Rating != null)
            {
                existingProduct.Rating.Rate = product.Rating.Rate;
                existingProduct.Rating.Count = product.Rating.Count;
            }

            _context.Products.Entry(existingProduct).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return existingProduct;
        }
    }
}
