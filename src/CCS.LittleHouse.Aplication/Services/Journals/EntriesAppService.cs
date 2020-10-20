using AutoMapper;
using CCS.LittleHouse.Aplication.DTO.Journals;
using CCS.LittleHouse.Aplication.Interfaces.Journals;
using CCS.LittleHouse.Domain.Models.Journals;
using CCS.LittleHouse.Domain.Repositories.Journals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.LittleHouse.Aplication.Services.Journals
{
    public class EntriesAppService : IEntriesAppService
    {
        private readonly IEntriesRepository _entriesRepository;
        private readonly IJournalsRepository _journalsRepository;
        private readonly IMapper _mapper;

        public EntriesAppService(IEntriesRepository entriesRepository
            , IJournalsRepository journalsRepository
            , IMapper mapper)
        {
            _entriesRepository = entriesRepository;
            _journalsRepository = journalsRepository;
            _mapper = mapper;
        }

        public async Task AddEntry(EntryDTO data)
        {
            await _journalsRepository.RunInTransaction(async () =>
            {
                Journal journal = _journalsRepository.GetById(data.JournalId);
                Entry entry = _mapper.Map<EntryDTO, Entry>(data);

                journal.AddEntry(entry);
                await _journalsRepository.Create(journal);
            });
        }

        public async Task EditEntry(EntryDTO data)
        {
            await _journalsRepository.RunInTransaction(async () =>
            {
                Journal journal = _journalsRepository.GetById(data.JournalId);
                Entry entry = _mapper.Map<EntryDTO, Entry>(data);

                journal.EditEntry(entry);
                await _journalsRepository.Create(journal);
            });
        }

        public async Task DeleteEntry(EntryDTO data)
        {
            await _journalsRepository.RunInTransaction(async () =>
            {
                Journal journal = _journalsRepository.GetById(data.JournalId);
                Entry entry = _mapper.Map<EntryDTO, Entry>(data);

                journal.DeleteEntry(entry);
                await _journalsRepository.Create(journal);
            });
        }

        public IList<EntryDTO> GetEntriesByJournal(Guid id)
        {
            IList<Entry> entries = _entriesRepository.GetAll.Where(entry => entry.Id.Equals(id)).ToList();
            return _mapper.Map<IList<Entry>, IList<EntryDTO>>(entries);
        }
    }
}
