using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleCommand : IRequest<CreateSaleResult>
{
    public string CartId { get; set; }
    public string CustomerName { get; set; }
    public string Branch { get; set; }
}