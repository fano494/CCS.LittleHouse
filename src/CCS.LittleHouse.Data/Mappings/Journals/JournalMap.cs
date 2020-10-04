using CCS.LittleHouse.Domain.Models.Journals;
using FluentNHibernate.Mapping;
using System;

namespace CCS.LittleHouse.Data.Mappings.Journals
{
    public class JournalMap : ClassMap<Journal>
    {
        public JournalMap()
        {
            Table("J_Journals");
            LazyLoad();
            Id(x => x.Id, "Id").GeneratedBy.Assigned();
            Map(x => x.CreateDateTime, "CreateDateTime").Not.Nullable();
            Map(x => x.EditDateTime, "EditDateTime").Not.Nullable();
            HasMany(x => x.Entries).KeyColumns.Add("JournalId").Cascade.DeleteOrphan().AsArray<DateTime>(x => x.CreateDateTime).Inverse();
            References(x => x.User, "UserId").Not.Nullable();
        }
    }
}
