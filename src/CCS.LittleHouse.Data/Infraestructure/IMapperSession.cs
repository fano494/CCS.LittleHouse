using CCS.LittleHouse.Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CCS.LittleHouse.Data.Infraestructure
{
    public interface IMapperSession
    {
        void BeginTransaction();
        Task Commit();
        Task Rollback();
        void CloseTransaction();
        Task Save<Tentity>(Tentity entity) where Tentity : Entity;
        Task Delete<Tentity>(Tentity entity) where Tentity : Entity;
        IQueryable<Tentity> GetAll<Tentity>() where Tentity : Entity;
        Tentity GetById<Tentity>(Guid id) where Tentity : Entity;
    }
}
