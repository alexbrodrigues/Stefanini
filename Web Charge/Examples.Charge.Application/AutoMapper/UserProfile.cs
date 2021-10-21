using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Domain.Aggregates.Identity;

namespace Examples.Charge.Application.AutoMapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
              .ReverseMap()
              .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
              .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
              .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password))
              .ForMember(dest => dest.NomeCompleto, opt => opt.MapFrom(src => src.FullName));
        }
    }
}
