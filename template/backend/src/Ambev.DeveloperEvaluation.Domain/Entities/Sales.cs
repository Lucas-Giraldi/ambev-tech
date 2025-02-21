using Ambev.DeveloperEvaluation.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a sale in the system.
/// This entity follows domain-driven design principles.
/// </summary>
public class Sales : BaseEntity
{
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
    public List<SalesItem> Items { get; set; } = new List<SalesItem>();

    /// <summary>
    /// Indicates whether the sale was canceled.
    /// </summary>
    public bool IsCanceled { get; set; }
}
