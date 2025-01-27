using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart
{
    public class UpdateCartResult
    {
        public string Id { get; set; }
        public Guid UserId { get; set; }
        public string Date { get; set; }
        public List<CartItem> Products { get; set; } = new();
    }
}
