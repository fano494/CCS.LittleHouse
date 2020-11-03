using CCS.LittleHouse.Data.Infraestructure;
using CCS.LittleHouse.Domain.Models;
using CCS.LittleHouse.Domain.Repositories;
using CCS.LittleHouse.Domain.Repositories.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CCS.LittleHouse.Data.Repositories
{
    public abstract class Repository<Tentity> : IRepository<Tentity> where Tentity : Entity
    {
        private readonly IHttpContextAccessor _contextAccessor;
        protected IMapperSession MapperSession => _contextAccessor.HttpContext.RequestServices.GetService(typeof(IMapperSession)) as IMapperSession;

        public Repository(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public IQueryable<Tentity> GetAll => MapperSession.GetAll<Tentity>();

        public async Task Delete(Tentity entity)
        {
            await MapperSession.Delete(entity);
        }

        public Tentity GetById(Guid id)
        {
            return MapperSession.GetById<Tentity>(id);
        }

        public async Task RunInTransaction(Func<Task> action)
        {
            try
            {
                MapperSession.BeginTransaction();

                await action();

                await MapperSession.Commit();
            }
            catch
            {
                await MapperSession.Rollback();

                throw;
            }
            finally
            {
                MapperSession.CloseTransaction();
            }
        }

        public async Task<T> RunInTransaction<T>(Func<Task<T>> func)
        {
            try
            {
                MapperSession.BeginTransaction();

                var retval = await func();

                await MapperSession.Commit();

                return retval;
            }
            catch
            {
                await MapperSession.Rollback();

                throw;
            }
            finally
            {
                MapperSession.CloseTransaction();
            }
        }

        public async Task Create(Tentity entity)
        {
            await MapperSession.Save(entity);
        }

        public async Task Update(Tentity entity)
        {
            await MapperSession.Update(entity);
        }
    }
}
