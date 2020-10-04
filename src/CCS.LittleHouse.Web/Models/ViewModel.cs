using CCS.LittleHouse.Aplication.DTO.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCS.LittleHouse.Web.Models
{
    public abstract class ViewModel
    {
        protected ViewModel(UserDTO user)
        {
            User = user;
        }

        public UserDTO User { get; }
    }
}
