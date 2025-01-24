using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProducts
{
    public class GetProductsRequestValidator : AbstractValidator<GetProductSRequest>
    {
        /// <summary>
        /// Initializes validation rules for GetProductRequest
        /// </summary>
        public GetProductsRequestValidator()
        {
            RuleFor(x => x.Page)
                .Must(page => int.TryParse(page.ToString(), out _))
                .WithMessage("page is not a integer number");

            RuleFor(x => x.Size)
                .Must(size => int.TryParse(size.ToString(), out _))
                .WithMessage("size is not a integer number");

            RuleFor(x => x.Order)
            .Must(order => new[] { "e.g", "price desc", "title asc" }.Contains(order))
            .WithMessage("The order must be one of the following: e.g, price desc, title asc.");
        }
    }
}
