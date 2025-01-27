using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCarts
{
    public class CartDto
    {
        /// <summary>
        /// Unique identifier for the cart.
        /// </summary>
        public string Id { get; set; } // Mantido como string para corresponder aos dados

        /// <summary>
        /// User ID associated with the cart.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Date when the cart was created or modified.
        /// </summary>
        public string Date { get; set; } // String para o formato de data

        /// <summary>
        /// List of products in the cart.
        /// </summary>
        public List<CartItem> Products { get; set; }
    }
}
