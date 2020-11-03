using CCS.LittleHouse.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCS.LittleHouse.Test.Unit.Models.Journals
{
    public class UserFake : User
    {
        public UserFake(string name) : base()
        {
            Name = name;
        }
    }
}
