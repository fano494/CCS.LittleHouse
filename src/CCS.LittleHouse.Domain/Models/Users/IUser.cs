using CCS.LittleHouse.Domain.Models.Journals;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCS.LittleHouse.Domain.Models.Users
{
    public interface IUser
    {
        public Journal[] Journals { get; protected set; }
    }
}
