using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.ListUsers;

public class ListUsersRequestValidator : AbstractValidator<ListUsersRequest>
{
    public ListUsersRequestValidator()
    {
        RuleFor(x => x.Page)
               .Must(page => int.TryParse(page.ToString(), out _))
               .WithMessage("page is not a integer number");

        RuleFor(x => x.Size)
            .Must(size => int.TryParse(size.ToString(), out _))
            .WithMessage("size is not a integer number");

        RuleFor(x => x.Order)
        .Must(order => new[] { "email desc", "username asc" }.Contains(order))
        .WithMessage("The order must be one of the following: email desc, username asc.");
    }
}
