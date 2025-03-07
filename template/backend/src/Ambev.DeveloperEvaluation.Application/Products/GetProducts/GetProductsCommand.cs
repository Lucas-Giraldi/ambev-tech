﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProducts
{
    public class GetProductsCommand : IRequest<GetProductResult>
    {
        /// <summary>
        /// Get current page.
        /// Must be a integer number.
        /// </summary>
        public int? Page { get; set; } = 1;

        /// <summary>
        /// Get size of page
        /// Must be a integer number.
        /// </summary>
        public int? Size { get; set; } = 10;

        /// <summary>
        /// Order to show the products.
        /// Must be a valid Enum OrderProducts.
        /// </summary>

        public string? Order { get; set; }
    }
}
