using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct
{
    /// <summary>
    /// Validator for the CreateProductRatingRequest.
    /// Ensures all rating fields meet the necessary requirements.
    /// </summary>
    public class CreateProductRatingRequestValidator : AbstractValidator<CreateProductRatingRequest>
    {
        public CreateProductRatingRequestValidator()
        {
            // Rate: Must be between 0 and 5
            RuleFor(rating => rating.Rate)
                .InclusiveBetween(0, 5).WithMessage("The product rating rate must be between 0 and 5.");

            // Count: Must be greater than or equal to 0
            RuleFor(rating => rating.Count)
                .GreaterThanOrEqualTo(0).WithMessage("The product rating count must be greater than or equal to 0.");
        }
    }
}
