using CCS.LittleHouse.Aplication.DTO.Journals;
using CCS.LittleHouse.Aplication.DTO.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCS.LittleHouse.Web.Models.Journals
{
    public class IndexViewModel : ViewModel
    {
        private IndexViewModel(UserDTO user, IEnumerable<JournalDTO> journals) : base(user)
        {
            Journals = journals;
        }

        public IEnumerable<JournalDTO> Journals { get; }

        public static IndexViewModel Create(UserDTO user, IEnumerable<JournalDTO> journals)
        {
            return new IndexViewModel(user, journals);
        }
    }
}
