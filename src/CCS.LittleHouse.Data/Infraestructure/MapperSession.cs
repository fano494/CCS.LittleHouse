using CCS.LittleHouse.Domain.Models;
using NHibernate;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CCS.LittleHouse.Data.Infraestructure
{
    public class MapperSession : IMapperSession
    {
        private readonly ISession _session;
        private ITransaction _transaction;

        public MapperSession(ISession session)
        {
            _session = session;
        }

        public IQueryable<Tentity> GetAll<Tentity>() where Tentity : Entity
        {
            return _session.Query<Tentity>();
        }

        public void BeginTransaction()
        {
            _transaction = _session.BeginTransaction();
        }

        public async Task Commit()
        {
            await _transaction.CommitAsync();
        }

        public async Task Rollback()
        {
            await _transaction.RollbackAsync();
        }

        public void CloseTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public async Task Save<Tentity>(Tentity entity) where Tentity : Entity
        {
            await _session.SaveOrUpdateAsync(entity);
        }

        public async Task Delete<Tentity>(Tentity entity) where Tentity : Entity
        {
            await _session.DeleteAsync(entity);
        }

        public Tentity GetById<Tentity>(Guid id) where Tentity : Entity
        {
            return _session.Get<Tentity>(id);
        }
    }
}
