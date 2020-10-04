using AutoMapper;
using CCS.LittleHouse.Aplication.DTO.Users;
using CCS.LittleHouse.Aplication.Interfaces.Users;
using CCS.LittleHouse.Domain.Models.Users;
using CCS.LittleHouse.Domain.Repositories.Users;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CCS.LittleHouse.Aplication.Services.Users
{
    public class UsersAppService : IUsersAppService
    {
        private readonly IMapper _mapper;
        private readonly IUsersRepository _usersRepository;

        public UsersAppService(IMapper mapper, IUsersRepository usersRepository)
        {
            _mapper = mapper;
            _usersRepository = usersRepository;
        }

        public UserDTO GetById(Guid id)
        {
            User user = _usersRepository.GetById(id);
            return _mapper.Map<User, UserDTO>(user);
        }

        public UserDTO Login(string userName)
        {
            User user = _usersRepository.GetAll.First(u => u.Name.Equals(userName));
            return _mapper.Map<User, UserDTO>(user);
        }

        public async Task<UserDTO> Register(string userName)
        {
            if (_usersRepository.IsNameUnique(userName))
            {
                return await _usersRepository.RunInTransaction(async () =>
                {
                    User user = new User(userName);
                    await _usersRepository.Save(user);
                    return _mapper.Map<User, UserDTO>(user);
                });
            }
            else
            {
                throw new InvalidOperationException("The name is currently in use");
            }
        }
    }
}
