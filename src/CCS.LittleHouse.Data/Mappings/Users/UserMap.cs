using CCS.LittleHouse.Domain.Models.Users;
using FluentNHibernate.Mapping;
using System;

namespace CCS.LittleHouse.Data.Mappings.Users
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("U_Users");
            LazyLoad();
            Id(x => x.Id, "Id").GeneratedBy.Assigned();
            Map(x => x.CreateDateTime, "CreateDateTime").Not.Nullable();
            Map(x => x.EditDateTime, "EditDateTime").Not.Nullable();
            Map(x => x.Name, "Name").Not.Nullable().Unique();
            HasMany(x => x.Journals).KeyColumns.Add("UserId").Cascade.DeleteOrphan().AsArray<DateTime>(x => x.CreateDateTime).Inverse(); ;
        }
    }
}
