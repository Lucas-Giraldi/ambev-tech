using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Users.DTOs;

namespace Ambev.DeveloperEvaluation.Application.Users.CreateUser;

/// <summary>
/// Profile for mapping between User entity and CreateUserResponse
/// </summary>
public class CreateUserProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateUser operation
    /// </summary>
    public CreateUserProfile()
    {
        CreateMap<CreateUserCommand, User>()
            .ForMember(dist=> dist.FirstName, user => user.MapFrom(src=> src.Name.FirstName))
            .ForMember(dist=> dist.LastName, user => user.MapFrom(src=> src.Name.LastName));


        CreateMap<User, CreateUserResult>()
           .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Username))
           .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.UserAddress.FirstOrDefault()))
           .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => new NameUsersDto
           {
               FirstName = src.FirstName,
               LastName = src.LastName
           }));

        CreateMap<UserAddress, AddressUserDto>()
            .ForMember(dest => dest.GeoLocation, opt => opt.MapFrom(src => new LocationUsersDto
            {
                Lat = src.Lat,
                Long = src.Long
            }));

        CreateMap<AddressUserDto, UserAddress>()
         .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
         .ForMember(dest => dest.Lat, opt => opt.MapFrom(src => src.GeoLocation != null ? src.GeoLocation.Lat : null))
         .ForMember(dest => dest.Long, opt => opt.MapFrom(src => src.GeoLocation != null ? src.GeoLocation.Long : null));

    }
}
