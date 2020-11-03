using AutoMapper;
using CCS.LittleHouse.Aplication.DTO.Users;
using CCS.LittleHouse.Aplication.Exceptions;
using CCS.LittleHouse.Aplication.Interfaces.Users;
using CCS.LittleHouse.Domain.Models.Users;
using CCS.LittleHouse.Domain.Repositories.Exceptions;
using CCS.LittleHouse.Domain.Repositories.Users;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CCS.LittleHouse.Aplication.Services.Users
{
    public class UsersAppService : IUsersAppService
    {
        private readonly IMapper _mapper;
        private readonly IUsersManager _usersManager;
        private readonly IUsersRepository _usersRepository;

        public UsersAppService(IMapper mapper, IUsersManager usersManager, IUsersRepository usersRepository)
        {
            _mapper = mapper;
            _usersManager = usersManager;
            _usersRepository = usersRepository;
        }

        public UserDTO GetById(Guid id)
        {
            try
            {
                User user = _usersManager.GetById(id);
                return _mapper.Map<UserDTO>(user);
            }
            catch(EntityNotFoundException ex)
            {
                throw new ResourceNotFoundException($"Resource User(Id: {id}) not found.", ex);
            }
            catch(InternalRepositoryException ex)
            {
                throw new RepositoryException("Users repository exception.", ex);
            }
            catch(Exception ex)
            {
                throw new InternalApplicationException("Users application exception.", ex);
            }
        }

        public UserDTO Login(string userName)
        {
            try
            {
                User user = _usersManager.GetAll.First(u => u.Name.Equals(userName));
                return _mapper.Map<UserDTO>(user);
            }
            catch (InvalidOperationException ex)
            {
                throw new ResourceNotFoundException($"Resource User(Name: {userName}) not found.", ex);
            }
            catch (InternalRepositoryException ex)
            {
                throw new RepositoryException("Users repository exception.", ex);
            }
            catch (Exception ex)
            {
                throw new InternalApplicationException("Users application exception.", ex);
            }
        }

        public async Task<UserDTO> Register(string userName)
        {
            try
            {
                return await _usersRepository.RunInTransaction(async () =>
                {
                    User user = _usersManager.CreateUser(userName);
                    await _usersRepository.Create(user);
                    return _mapper.Map<UserDTO>(user);
                });
            }
            catch (ExistingUserException ex)
            {
               throw new ExistingResourceException($"Exising User(Name: {userName}) exception.", ex);
            }
            catch (NullUserNameException ex)
            {
                throw new InvalidArgumentException("User name (NULL) not valid.", ex);
            } 
            catch (InternalRepositoryException ex)
            {
                throw new RepositoryException("Users repository exception.", ex);
            }
            catch (Exception ex)
            {
                throw new InternalApplicationException("Users application exception.", ex);
            }
        }

        public async Task EditUserName(UserDTO data)
        {
            try
            {
                await _usersRepository.RunInTransaction(async () =>
                {
                    User user = _usersManager.GetById(data.Id);
                    _usersManager.EditName(user, data.Name);
                    await _usersRepository.Update(user);
                });
            }
            catch (NullUserNameException ex)
            {
                throw new InvalidArgumentException("User name (NULL) not valid.", ex);
            }
            catch (ExistingUserException ex)
            {
                throw new ExistingResourceException($"Exising User(Name: {data.Name}) exception.", ex);
            }
            catch (InternalRepositoryException ex)
            {
                throw new RepositoryException("Users repository exception.", ex);
            }
            catch (Exception ex)
            {
                throw new InternalApplicationException("Users application exception.", ex);
            }
        }
    }
}
