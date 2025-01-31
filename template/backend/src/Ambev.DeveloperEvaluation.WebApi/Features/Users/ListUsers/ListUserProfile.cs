using Ambev.DeveloperEvaluation.Application.Users.ListUsers;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.ListUsers
{
    public class ListUserProfile : Profile
    {
        public ListUserProfile()
        {
            CreateMap<ListUsersRequest, ListUsersCommand>();
            CreateMap<ListUsersResult, ListUsersResponse>();
        }
    }
}
