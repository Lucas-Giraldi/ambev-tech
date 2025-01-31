using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Users.ListUsers;

public class ListUserHandle : IRequestHandler<ListUsersCommand, List<ListUsersResult>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public ListUserHandle(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<List<ListUsersResult>> Handle(ListUsersCommand request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAll(request.Page.Value, request.Size.Value, request?.Order ?? "");
        try
        {
            return users.Select(p => new ListUsersResult
            {
                Status = p.Status,
                Username = p.Username,
                Name = new DTOs.NameUsersDto
                {
                    FirstName = p.Username.Split(' ').FirstOrDefault(),
                    LastName = p.Username.Split(' ').LastOrDefault()
                },
                Email = p.Email,
                Id = p.Id,
                Password = p.Password,
                Phone = p.Phone,
                Role = p.Role
            }).ToList();
        }
        catch (AutoMapperMappingException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.InnerException?.Message);
            throw;
        }

    }
}
