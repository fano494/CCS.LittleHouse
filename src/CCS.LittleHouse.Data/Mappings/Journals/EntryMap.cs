using CCS.LittleHouse.Domain.Models.Journals;
using FluentNHibernate.Mapping;

namespace CCS.LittleHouse.Data.Mappings.Journals
{
    public class EntryMap : ClassMap<Entry>
    {
        public EntryMap()
        {
            Table("J_Entries");
            LazyLoad();
            Id(x => x.Id, "Id").GeneratedBy.Assigned();
            Map(x => x.CreateDateTime, "CreateDateTime").Not.Nullable();
            Map(x => x.EditDateTime, "EditDateTime").Not.Nullable();
            Map(x => x.Interval, "Interval").Not.Nullable();
            Map(x => x.State, "State").Not.Nullable();
            References(x => x.Journal, "JournalId").Not.Nullable();
        }
    }
}
