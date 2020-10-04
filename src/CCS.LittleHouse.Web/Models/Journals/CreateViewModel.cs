using CCS.LittleHouse.Aplication.DTO.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCS.LittleHouse.Web.Models.Journals
{
    public class CreateViewModel : ViewModel
    {
        private CreateViewModel(UserDTO user) : base(user)
        {
        }

        public static CreateViewModel Create(UserDTO user)
        {
            return new CreateViewModel(user);
        }
    }
}
