using CCS.LittleHouse.Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CCS.LittleHouse.Domain.Repositories
{
    public interface IRepository<Tentity> where Tentity : Entity
    {
        Tentity GetById(Guid id);
        IQueryable<Tentity> GetAll { get; }
        Task Create(Tentity entity);
        Task Update(Tentity entity);
        Task Delete(Tentity entity);
        Task RunInTransaction(Action action);
        Task<T> RunInTransaction<T>(Func<Task<T>> func);
    }
}
