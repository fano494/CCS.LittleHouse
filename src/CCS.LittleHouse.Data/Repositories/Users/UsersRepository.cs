using CCS.LittleHouse.Domain.Models.Users;
using CCS.LittleHouse.Domain.Repositories.Users;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace CCS.LittleHouse.Data.Repositories.Users
{
    public class UsersRepository : Repository<User>, IUsersRepository
    {
        public UsersRepository(IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {
        }

        public bool IsNameUnique(string name)
        {
            return GetAll.FirstOrDefault(user => user.Name.Equals(name)) is null;
        }
    }
}
