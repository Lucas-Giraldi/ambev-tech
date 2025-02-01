using Ambev.DeveloperEvaluation.Application.Users.DTOs;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Users.UpdateUser;

public class UpdateUserResult
{
    /// <summary>
    /// Get user id.
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Gets or sets the user's email address.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the username.
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the user's password.
    /// </summary>
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the user's name.
    /// </summary>
    public NameUsersDto Name { get; set; } = new();

    /// <summary>
    /// Gets or sets the user's address.
    /// </summary>
    public AddressUserDto Address { get; set; } = new();

    /// <summary>
    /// Gets or sets the user's phone number.
    /// </summary>
    public string Phone { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the user's status.
    /// </summary>
    public UserStatus Status { get; set; }

    /// <summary>
    /// Gets or sets the user's role.
    /// </summary>
    public UserRole Role { get; set; }
}
