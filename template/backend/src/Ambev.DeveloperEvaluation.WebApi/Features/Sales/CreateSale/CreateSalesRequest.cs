namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public class CreateSalesRequest
{
    public int CartId { get; set; }
    public string CostumerName { get; set; }

    public string Branch { get; set; }
}
