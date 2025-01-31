using Ambev.DeveloperEvaluation.Application.Users.DTOs;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.ListUsers;

public class ListUsersResponse
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
