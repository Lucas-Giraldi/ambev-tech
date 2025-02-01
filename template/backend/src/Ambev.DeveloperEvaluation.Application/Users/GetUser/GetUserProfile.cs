using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Users.DTOs;

namespace Ambev.DeveloperEvaluation.Application.Users.GetUser;

/// <summary>
/// Profile for mapping between User entity and GetUserResponse
/// </summary>
public class GetUserProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetUser operation
    /// </summary>
    public GetUserProfile()
    {
        CreateMap<User, GetUserResult>()
              .ForMember(dest => dest.Address, opt =>
                  opt.Condition(src => src.UserAddress != null))
              .ForMember(dest => dest.Address, opt =>
                  opt.MapFrom(src => src.UserAddress))
              .ForPath(dest => dest.UserName.FirstName, opt =>
                  opt.MapFrom(src => src.FirstName))
              .ForPath(dest => dest.UserName.LastName, opt =>
                  opt.MapFrom(src => src.LastName));

        CreateMap<UserAddress, AddressUserDto>()
            .ForMember(dest => dest.GeoLocation, opt => opt.MapFrom(src => new LocationUsersDto
            {
                Lat = src.Lat,
                Long = src.Long
            }));
    }
}
