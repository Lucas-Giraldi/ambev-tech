using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart
{
    public class UpdateCartResponse
    {
        public string Id { get; set; }
        public Guid UserId { get; set; }
        public string Date { get; set; }
        public List<CartItem> Products { get; set; } = new();
    }
}
