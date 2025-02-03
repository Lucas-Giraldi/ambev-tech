using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Users.DTOs;
using Ambev.DeveloperEvaluation.Application.Users.GetUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Users.UpdateUser
{
    public class UpdateUserProfile : Profile
    {
        public UpdateUserProfile()
        {
            CreateMap<UpdateUserCommand, User>()
                .ForMember(dest => dest.Password, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.UserAddress, opt => opt.MapFrom(src => src.Address))
                .ForPath(dest => dest.FirstName, opt => opt.MapFrom(src => src.Name.FirstName))
                .ForPath(dest => dest.LastName, opt => opt.MapFrom(src => src.Name.LastName));

            CreateMap<AddressUserDto, UserAddress>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Lat, opt => opt.MapFrom(src => src.GeoLocation.Lat))
                .ForMember(dest => dest.Long, opt => opt.MapFrom(src => src.GeoLocation.Long));

            CreateMap<User, UpdateUserResult>()
             .ForMember(dest => dest.Address, opt =>
                 opt.Condition(src => src.UserAddress != null))
             .ForMember(dest => dest.Address, opt =>
                 opt.MapFrom(src => src.UserAddress))
             .ForPath(dest => dest.Name.FirstName, opt =>
                 opt.MapFrom(src => src.FirstName))
             .ForPath(dest => dest.Name.LastName, opt =>
                 opt.MapFrom(src => src.LastName));

            CreateMap<UserAddress, AddressUserDto>()
           .ForMember(dest => dest.GeoLocation, opt => opt.MapFrom(src => new LocationUsersDto
           {
               Lat = src.Lat,
               Long = src.Long
           }));
        }
    }
}
