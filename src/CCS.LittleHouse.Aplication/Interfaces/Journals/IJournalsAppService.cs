using CCS.LittleHouse.Aplication.DTO.Journals;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CCS.LittleHouse.Aplication.Interfaces.Journals
{
    public interface IJournalsAppService
    {
        IList<JournalDTO> GetJournalsByUser(Guid id);
        Task AddJournal(JournalDTO data);
        Task DeleteJournal(JournalDTO data);
    }
}
