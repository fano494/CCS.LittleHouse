using System;
using System.Collections.Generic;
using System.Text;

namespace CCS.LittleHouse.Aplication.DTO.Journals
{
    public class EntryDTO : EntityDTO
    {
        public Guid JournalId { get; set; }
        public string Interval { get; set; }
        public string State { get; set; }
    }
}
