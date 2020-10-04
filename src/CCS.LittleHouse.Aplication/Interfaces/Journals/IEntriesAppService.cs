using CCS.LittleHouse.Aplication.DTO.Journals;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CCS.LittleHouse.Aplication.Interfaces.Journals
{
    public interface IEntriesAppService
    {
        IList<EntryDTO> GetEntriesByJournal(Guid id);
        Task AddEntry(EntryDTO data);
        Task EditEntry(EntryDTO data);
        Task DeleteEntry(EntryDTO data);
    }
}
