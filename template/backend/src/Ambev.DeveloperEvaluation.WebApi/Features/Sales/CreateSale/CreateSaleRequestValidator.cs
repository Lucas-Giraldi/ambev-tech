using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    /// <summary>
    /// Validator for the CreateSalesRequest class.
    /// </summary>
    public class CreateSaleRequestValidator : AbstractValidator<CreateSalesRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSaleRequestValidator"/> class.
        /// </summary>
        public CreateSaleRequestValidator()
        {
            RuleFor(x => x.CartId)
                .NotEmpty().WithMessage("CartId is required.")
                .GreaterThan(0).WithMessage("CartId must be greater than 0.");

            RuleFor(x => x.CostumerName)
                .NotEmpty().WithMessage("Customer name is required."); 

            RuleFor(x => x.Branch);
        }
    }
}
