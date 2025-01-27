using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ICartRepository
    {
        Task<Cart> CreateCart(Cart cart);

        Task<List<Cart>> GetAllCarts(int page, int size, string order);

        Task<Cart> GetCartById(string Id);

        Task<Cart> UpdateCart(Cart cart);

        Task Delete(string id);
    }
}
