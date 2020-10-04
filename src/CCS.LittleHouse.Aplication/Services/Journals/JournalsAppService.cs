using AutoMapper;
using CCS.LittleHouse.Aplication.DTO.Journals;
using CCS.LittleHouse.Aplication.Interfaces.Journals;
using CCS.LittleHouse.Domain.Models.Journals;
using CCS.LittleHouse.Domain.Models.Users;
using CCS.LittleHouse.Domain.Repositories.Journals;
using CCS.LittleHouse.Domain.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.LittleHouse.Aplication.Services.Journals
{
    public class JournalsAppService : IJournalsAppService
    {
        private readonly IJournalsRepository _journalsRepository;
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;

        public JournalsAppService(IJournalsRepository journalsRepository, IUsersRepository usersRepository, IMapper mapper)
        {
            _journalsRepository = journalsRepository;
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        public async Task AddJournal(JournalDTO data)
        {
            await _usersRepository.RunInTransaction(async () =>
            {
                User user = _usersRepository.GetById(data.UserId);
                Journal journal = _mapper.Map<JournalDTO, Journal>(data);

                user.AddJournal(journal);
                await _usersRepository.Save(user);
            });
        }

        public async Task DeleteJournal(JournalDTO data)
        {
            await _usersRepository.RunInTransaction(async () =>
            {
                User user = _usersRepository.GetById(data.UserId);
                Journal journal = _mapper.Map<JournalDTO, Journal>(data);

                user.DeleteJournal(journal);
                await _usersRepository.Save(user);
            });
        }

        public IList<JournalDTO> GetJournalsByUser(Guid id)
        {
            IList<Journal> journals = _journalsRepository.GetAll.Where(x => x.User.Id.Equals(id)).ToList();
            return _mapper.Map<IList<Journal>, IList<JournalDTO>>(journals);
        }
    }
}
