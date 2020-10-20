using CCS.LittleHouse.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCS.LittleHouse.Test.Unit.Models.Users
{
    public class UserFake : User
    {
        public UserFake(string username)
        {
            Name = username;
        }
    }
}
