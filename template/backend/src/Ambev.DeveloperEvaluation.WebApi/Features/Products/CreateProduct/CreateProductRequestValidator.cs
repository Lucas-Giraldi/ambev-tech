using System.Linq;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct
{
    /// <summary>
    /// Validator for the CreateProductRequest.
    /// Ensures all fields meet the necessary requirements.
    /// </summary>
    public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
    {
        public CreateProductRequestValidator()
        {
            // Title: Required and must not be empty
            RuleFor(request => request.Title)
                .NotEmpty().WithMessage("The product title is required.")
                .MaximumLength(100).WithMessage("The product title must not exceed 100 characters.");

            // Price: Required and must be greater than or equal to 0
            RuleFor(request => request.Price)
                .GreaterThanOrEqualTo(0).WithMessage("The product price must be greater than or equal to 0.");

            // Description: Required and must not be empty
            RuleFor(request => request.Description)
                .NotEmpty().WithMessage("The product description is required.")
                .MaximumLength(500).WithMessage("The product description must not exceed 500 characters.");

            // Category: Required and must not be empty
            RuleFor(request => request.Category)
                .NotEmpty().WithMessage("The product category is required.")
                .MaximumLength(50).WithMessage("The product category must not exceed 50 characters.");

            // Image: Optional, but if provided, must be a valid URL
            RuleFor(request => request.Image)
                .Must(IsValidUrl)
                .When(request => !string.IsNullOrEmpty(request.Image))
                .WithMessage("The product image must be a valid URL.");

        }

        private bool IsValidUrl(string imageUrl)
        {
            return Uri.TryCreate(imageUrl, UriKind.Absolute, out var uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}
