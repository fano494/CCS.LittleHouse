using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.LittleHouse.Domain.Models.Users
{
    public interface IUsersManager
    {
        IQueryable<User> GetAll { get; }
        User GetById(Guid id);
        Task<User> CreateUser(string name);
        Task EditName(User user, string name);
    }
}
