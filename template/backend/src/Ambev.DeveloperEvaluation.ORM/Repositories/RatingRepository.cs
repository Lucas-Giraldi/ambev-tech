using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class RatingRepository : IRatingRepository
    {

        private readonly DefaultContext _context;

        /// <summary>
        /// Initializes a new instance of UserRepository
        /// </summary>
        /// <param name="context">The database context</param>
        public RatingRepository(DefaultContext context)
        {
            _context = context;
        }
        public async Task<ProductRating> Create(ProductRating rating)
        {
            _context.Rating.Add(rating);

            await _context.SaveChangesAsync();

            return rating;
        }
    }
}
