﻿using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

namespace Ambev.DeveloperEvaluation.Application.Sales.ModifySale;

public class ModifySaleResult
{
    public Guid Id { get; set; }

    public int SaleNumber { get; set; }

    /// <summary>
    /// Date when the sale was made.
    /// </summary>
    public DateTime SaleCreate { get; set; }

    /// <summary>
    /// Customer who made the purchase.
    /// </summary>
    public string CustomerName { get; set; }

    /// <summary>
    /// Total value of the sale.
    /// </summary>
    public decimal TotalSaleValue { get; set; }

    /// <summary>
    /// Branch where the sale was made.
    /// </summary>
    public string Branch { get; set; }

    /// <summary>
    /// List of items sold in the sale.
    /// </summary>
    public List<ModifySaleItemResult> Items { get; set; } = new List<ModifySaleItemResult>();

    /// <summary>
    /// Indicates whether the sale was canceled.
    /// </summary>
    public bool IsCanceled { get; set; }
}
