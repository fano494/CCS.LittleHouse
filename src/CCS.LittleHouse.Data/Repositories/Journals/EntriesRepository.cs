using CCS.LittleHouse.Domain.Models.Journals;
using CCS.LittleHouse.Domain.Repositories.Journals;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCS.LittleHouse.Data.Repositories.Journals
{
    public class EntriesRepository : Repository<Entry>, IEntriesRepository
    {
        public EntriesRepository(IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {
        }
    }
}
