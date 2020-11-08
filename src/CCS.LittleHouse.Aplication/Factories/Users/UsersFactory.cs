using CCS.LittleHouse.Domain.Models.Users;
using CCS.LittleHouse.Domain.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.LittleHouse.Application.Factories.Users
{
    public class UsersFactory : IUsersFactory
    {
        private readonly IUsersRepository _usersRepository;
        
        public UsersFactory(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public User CreateUser(string name)
        {
            if (_usersRepository.IsNameUnique(name))
            {
                User user = User.Create(name);
                return user;
            }
            else
            {
                throw new ExistingUserException($"Exising User(Name: {name}) exception.");
            }
        }

        public void EditName(User user, string name)
        {
            if (_usersRepository.IsNameUnique(name))
            {
                user.EditName(name);
            }
            else
            {
                throw new ExistingUserException($"Exising User(Name: {name}) exception.");
            }
        }
    }
}
