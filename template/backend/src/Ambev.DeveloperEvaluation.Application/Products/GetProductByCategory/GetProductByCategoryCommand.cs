using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProductByCategory
{
    public class GetProductByCategoryCommand : IRequest<List<GetProductByCategoryResult>>
    {
        public string Category { get; set; }
    }
}
