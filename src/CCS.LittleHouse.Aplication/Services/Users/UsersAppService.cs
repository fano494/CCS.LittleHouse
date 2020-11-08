using AutoMapper;
using CCS.LittleHouse.Aplication.DTO.Users;
using CCS.LittleHouse.Aplication.Exceptions;
using CCS.LittleHouse.Aplication.Interfaces.Users;
using CCS.LittleHouse.Application.Factories.Users;
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
        private readonly IUsersFactory _usersFactory;
        private readonly IUsersRepository _usersRepository;

        public UsersAppService(IMapper mapper, IUsersFactory usersFactory, IUsersRepository usersRepository)
        {
            _mapper = mapper;
            _usersRepository = usersRepository;
            _usersFactory = usersFactory;
        }

        public UserDTO GetById(Guid id)
        {
            try
            {
                User user = _usersRepository.GetById(id);
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
                User user = _usersRepository.GetAll.First(u => u.Name.Equals(userName));
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
                    User user = _usersFactory.CreateUser(userName);
                    await _usersRepository.Create(user);
                    return _mapper.Map<UserDTO>(user);
                });
            }
            catch (ExistingUserException ex)
            {
               throw new ExistingResourceException($"Exising User(Name: {userName}) exception.", ex);
            }
            catch (LengthUserNameException ex)
            {
                throw new InvalidArgumentException($"User name(Name: {userName}) not valid.", ex);
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
                    User user = _usersRepository.GetById(data.Id);
                    _usersFactory.EditName(user, data.Name);
                    await _usersRepository.Update(user);
                });
            }
            catch (NullUserNameException ex)
            {
                throw new InvalidArgumentException("User name (NULL) not valid.", ex);
            }
            catch (LengthUserNameException ex)
            {
                throw new InvalidArgumentException($"User name(Name: {data.Name}) not valid.", ex);
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
