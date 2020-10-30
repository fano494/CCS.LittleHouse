using CCS.LittleHouse.Domain.Models.Journals;
using CCS.LittleHouse.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCS.LittleHouse.Test.Unit.Models.Journals
{
    public class JournalFake : Journal
    {
        public JournalFake(DateTime createDateTime) : base()
        {
            CreateDateTime = createDateTime;
        }

        public JournalFake(User user) : base()
        {
            User = user;
        }
    }
}
