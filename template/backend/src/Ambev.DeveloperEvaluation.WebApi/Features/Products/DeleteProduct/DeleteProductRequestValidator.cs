using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.DeleteProduct
{
    public class DeleteProductRequestValidator : AbstractValidator<int>
    {
        public DeleteProductRequestValidator()
        {
            RuleFor(id => id)
               .GreaterThan(0)
               .WithMessage("The Id must not be empty or null.");
        }
    }
}
