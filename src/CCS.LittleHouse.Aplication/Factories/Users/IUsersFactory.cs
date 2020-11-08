using CCS.LittleHouse.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.LittleHouse.Application.Factories.Users
{
    public interface IUsersFactory
    {
        User CreateUser(string name);
        void EditName(User user, string name);
    }
}
