using CCS.LittleHouse.Domain.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.LittleHouse.Domain.Models.Users
{
    public class UsersManager : IUsersManager
    {
        private readonly IUsersRepository _usersRepository;

        public UsersManager(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public IQueryable<User> GetAll => _usersRepository.GetAll;

        public User GetById(Guid id)
        {
            return _usersRepository.GetById(id);
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
