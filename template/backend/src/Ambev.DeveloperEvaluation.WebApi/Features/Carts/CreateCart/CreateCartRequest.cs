
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart
{
    public class CreateCartRequest
    {
        public Guid UserId { get; set; }
        public string Date { get; set; }
        public List<CartItem> Products { get; set; }
    }
}
