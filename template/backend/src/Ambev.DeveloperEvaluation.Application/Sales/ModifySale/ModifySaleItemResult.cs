namespace Ambev.DeveloperEvaluation.Application.Sales.ModifySale;

public class ModifySaleItemResult
{
    public int ProductId { get; set; }

    public Guid SaleId { get; set; }

    public decimal Value { get; set; }

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
        get { return Quantity * Value - Discount; }
    }
}
