using CCS.LittleHouse.Aplication.DTO.Users;
using System;
using System.Threading.Tasks;

namespace CCS.LittleHouse.Aplication.Interfaces.Users
{
    public interface IUsersAppService
    {
        UserDTO GetById(Guid id);
        UserDTO Login(string userName);
        Task<UserDTO> Register(string userName);
    }
}
