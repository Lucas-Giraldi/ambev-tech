using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct
{
    public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductRequestValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("The product title is required.")
                .MaximumLength(100).WithMessage("The title must not exceed 100 characters.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("The product price must be greater than zero.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("The product description is required.");

            RuleFor(x => x.Category)
                .NotEmpty().WithMessage("The product category is required.");

            RuleFor(x => x.Image)
                .NotEmpty().WithMessage("The product image is required.")
                .Must(IsValidUrl).WithMessage("The product image must be a valid URL.");

            RuleFor(x => x.Rating.Rate)
                .InclusiveBetween(0, 5).WithMessage("The rating rate must be between 0 and 5.");

            RuleFor(x => x.Rating.Count)
                .GreaterThanOrEqualTo(0).WithMessage("The rating count must be a non-negative integer.");
        }
        private bool IsValidUrl(string imageUrl)
        {
            return Uri.TryCreate(imageUrl, UriKind.Absolute, out _);
        }
    }
}
