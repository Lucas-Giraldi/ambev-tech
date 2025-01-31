using Ambev.DeveloperEvaluation.Application.Users.DTOs;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Users.ListUsers;

public class ListUsersResult
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    public NameUsersDto Name { get; set; }
    public AddressUserDto Address { get; set; }
    public string Phone { get; set; }
    public UserStatus Status { get; set; }
    public UserRole Role { get; set; }
}
