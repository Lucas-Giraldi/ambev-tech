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

        public async Task<Product> GetById(int id)
        {
            return await _context.Products.Include(p=>p.Rating).FirstOrDefaultAsync(p=> p.Id == id);
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
    }
}
