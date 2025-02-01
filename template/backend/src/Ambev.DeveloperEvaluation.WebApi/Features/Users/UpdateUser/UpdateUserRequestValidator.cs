using FluentValidation;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.UpdateUser;

public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
{
    public UpdateUserRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");

        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Username is required.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.");

        RuleFor(x => x.Name)
            .NotNull().WithMessage("Name is required.")
            .ChildRules(name =>
            {
                name.RuleFor(n => n.FirstName)
                    .NotEmpty().WithMessage("First name is required.");

                name.RuleFor(n => n.LastName)
                    .NotEmpty().WithMessage("Last name is required.");
            });

        RuleFor(x => x.Address)
            .NotNull().WithMessage("Address is required.")
            .ChildRules(address =>
            {
                address.RuleFor(a => a.City)
                    .NotEmpty().WithMessage("City is required.");

                address.RuleFor(a => a.Street)
                    .NotEmpty().WithMessage("Street is required.");

                address.RuleFor(a => a.Number)
                    .GreaterThan(0).WithMessage("Number must be greater than zero.");

                address.RuleFor(a => a.ZipCode)
                    .NotEmpty().WithMessage("ZipCode is required.");

                address.RuleFor(a => a.GeoLocation)
                    .NotNull().WithMessage("GeoLocation is required.")
                    .ChildRules(geo =>
                    {
                        geo.RuleFor(g => g.Lat)
                            .NotEmpty().WithMessage("Latitude is required.");

                        geo.RuleFor(g => g.Long)
                            .NotEmpty().WithMessage("Longitude is required.");
                    });
            });

        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage("Phone is required.");

        RuleFor(x => x.Status)
            .IsInEnum().WithMessage("Invalid status value.");

        RuleFor(x => x.Role)
            .IsInEnum().WithMessage("Invalid role value.");
    }
}
