using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;
public class GetProductRequestValidator : AbstractValidator<int>
{

    public GetProductRequestValidator()
    {
        RuleFor(id => id)
       .GreaterThan(0)
       .WithMessage("The Id must not be empty or null.");
    }
}
