using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCartById
{
    public class GetCartByIdResult
    {
        public string Id { get; set; }
        public Guid UserId { get; set; }
        public string Date { get; set; }
        public List<CartItem> Products { get; set; } = new();
    }
}
