using CCS.LittleHouse.Domain.Models;
using CCS.LittleHouse.Domain.Repositories.Exceptions;
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
            try
            {
                return _session.Query<Tentity>();
            }
            catch (Exception ex)
            {
                throw new InternalRepositoryException($"Get all {typeof(Tentity).Name} exception.", ex);
            }
            
        }

        public void BeginTransaction()
        {
            try
            {
                _transaction = _session.BeginTransaction();
            }
            catch (Exception ex)
            {
                throw new InternalRepositoryException($"Begin transaction exception.", ex);
            }
        }

        public async Task Commit()
        {
            try
            {
                await _transaction.CommitAsync();
            }
            catch(Exception ex)
            {
                throw new InternalRepositoryException($"Commit exception.", ex);
            }
        }

        public async Task Rollback()
        {
            try
            {
                await _transaction.RollbackAsync();
            }
            catch (Exception ex)
            {
                throw new RollbackException($"Rollback exception.", ex);
            }
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
            try
            {
                await _session.SaveAsync(entity);
            }
            catch(Exception ex)
            {
                throw new InternalRepositoryException($"Create {typeof(Tentity).Name}(Id: {entity.Id}) exception.", ex);
            }
        }

        public async Task Update<Tentity>(Tentity entity) where Tentity : Entity
        {
            try
            {
                await _session.UpdateAsync(entity);
            }
            catch (Exception ex)
            {
                throw new InternalRepositoryException($"Update {typeof(Tentity).Name}(Id: {entity.Id}) exception.", ex);
            }
        }

        public async Task Delete<Tentity>(Tentity entity) where Tentity : Entity
        {
            try
            {
                await _session.DeleteAsync(entity);
            }
            catch (Exception ex)
            {
                throw new InternalRepositoryException($"Delete {typeof(Tentity).Name}(Id: {entity.Id}) exception.", ex);
            }
        }

        public Tentity GetById<Tentity>(Guid id) where Tentity : Entity
        {
            try
            {
                return _session.Get<Tentity>(id);
            }
            catch (ObjectNotFoundException ex)
            {
                throw new EntityNotFoundException($"Not found entity {typeof(Tentity).Name}(Id: {id}).", ex);
            }
            catch (Exception ex)
            {
                throw new InternalRepositoryException($"Get by id {typeof(Tentity).Name}(Id: {id}) exception.", ex);
            }
        }
    }
}
