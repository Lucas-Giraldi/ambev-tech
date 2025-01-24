using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IRatingRepository
    {

        /// <summary>
        /// Create product rating
        /// </summary>
        /// <returns>product rating</returns>
        Task<ProductRating> Create(ProductRating rating);

    }
}
