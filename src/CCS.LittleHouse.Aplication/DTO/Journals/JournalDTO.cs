using System;
using System.Collections.Generic;
using System.Text;

namespace CCS.LittleHouse.Aplication.DTO.Journals
{
    public class JournalDTO : EntityDTO
    {
        public Guid UserId { get; set; }
        public EntryDTO[] Entries { get; set; }
    }
}
