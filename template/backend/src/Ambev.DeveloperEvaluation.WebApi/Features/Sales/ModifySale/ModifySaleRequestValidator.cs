using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.ModifiedSale;

public class ModifySaleRequestValidator : AbstractValidator<ModifySaleRequest>
{

    public ModifySaleRequestValidator()
    {
        RuleFor(x => x.CartId)
              .NotEmpty().WithMessage("CartId is required.");

        RuleFor(x => x.CustomerName)
            .NotEmpty().WithMessage("Customer name is required.");

        RuleFor(x => x.Branch).NotEmpty().WithMessage("Branch is required.");
    }
}
