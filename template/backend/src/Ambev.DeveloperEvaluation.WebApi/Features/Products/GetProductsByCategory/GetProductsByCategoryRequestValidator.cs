using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProductsByCategory
{
    public class GetProductsByCategoryRequestValidator : AbstractValidator<string>
    {
        public GetProductsByCategoryRequestValidator()
        {

            RuleFor(category => category)
                .NotNull().WithMessage("The is null.")
                .NotEmpty().WithMessage("The is empty.");
        }
    }
}
