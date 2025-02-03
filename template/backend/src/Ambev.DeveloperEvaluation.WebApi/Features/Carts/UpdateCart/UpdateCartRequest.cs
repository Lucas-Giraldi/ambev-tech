using System.Text.Json.Serialization;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart
{
    public class UpdateCartRequest
    {
        [JsonIgnore]
        public string? Id { get; set; }
        public Guid UserId { get; set; }
        public string Date { get; set; }
        public List<CartItem> Products { get; set; }
    }
}
