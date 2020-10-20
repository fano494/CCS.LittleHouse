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

        public async Task<User> CreateUser(string name)
        {
            if (_usersRepository.IsNameUnique(name))
            {
                return await _usersRepository.RunInTransaction(async () =>
                {
                    User user = User.Create(name);
                    await _usersRepository.Create(user);
                    return user;
                });
            }
            else
            {
                throw new InvalidOperationException("The name is currently in use");
            }
        }

        public async Task EditName(User user, string name)
        {
            if (_usersRepository.IsNameUnique(name))
            {
                await _usersRepository.RunInTransaction(async () =>
                {
                    user.EditName(name);
                    await _usersRepository.Update(user);
                });
            }
            else
            {
                throw new InvalidOperationException("The name is currently in use");
            }
        }
    }
}
