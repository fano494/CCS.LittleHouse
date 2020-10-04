using AutoMapper;
using CCS.LittleHouse.Aplication.DTO.Users;
using CCS.LittleHouse.Domain.Models.Users;

namespace CCS.LittleHouse.Aplication.AutoMapper.Users
{
    public class UsersMappingProfile : Profile
    {
        public UsersMappingProfile()
        {
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();
        }
    }
}
