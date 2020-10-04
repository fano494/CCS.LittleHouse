using CCS.LittleHouse.Domain.Models.Users;

namespace CCS.LittleHouse.Domain.Repositories.Users
{
    public interface IUsersRepository : IRepository<User>
    {
        bool IsNameUnique(string name);
    }
}
