using Ambev.DeveloperEvaluation.Application.Users.DTOs;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Users.ListUsers;

public class ListUserProfile : Profile
{
    public ListUserProfile()
    {
        CreateMap<User, ListUsersResult>()
          .ForMember(dest => dest.Username, opt => opt.MapFrom(src=> src.Username))
          .ForMember(dest => dest.Password, opt => opt.MapFrom(src=> src.Password))
          .ForMember(dest => dest.Phone, opt => opt.MapFrom(src=> src.Phone))
          .ForMember(dest => dest.Status, opt => opt.MapFrom(src=> src.Status))
          .ForMember(dest => dest.Role, opt => opt.MapFrom(src=> src.Role))
          .ForMember(dest => dest.Address, opt => opt.MapFrom(src => new AddressUserDto
          {
              City = "City",
              Street = "Street Name",
              Number = 123,
              ZipCode = "12345",
              GeoLocation = new LocationUsersDto { Lat = "0", Long = "0" }
          }));

    }
    private string GetFirstName(string username)
    {
        return username?.Split(' ').FirstOrDefault();
    }

    private string GetLastName(string username)
    {
        return username?.Split(' ').LastOrDefault();
    }

}
