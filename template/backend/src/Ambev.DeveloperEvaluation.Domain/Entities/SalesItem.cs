﻿using Ambev.DeveloperEvaluation.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class SalesItem : BaseEntity
{
    public Product Product { get; set; }

    public Sales Sale { get; set; }

    /// <summary>
    /// Quantity of the product sold.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Discount applied to the item.
    /// </summary>
    public decimal Discount { get; set; }

    /// <summary>
    /// Total value of the item (quantity * unit price - discount).
    /// </summary>
    public decimal TotalItemValue
    {
        get { return Quantity * Product.Price - Discount; }
    }
}
