using AutoMapper;
using CCS.LittleHouse.Aplication.AutoMapper.Users;
using CCS.LittleHouse.Aplication.DTO.Users;
using CCS.LittleHouse.Aplication.Exceptions;
using CCS.LittleHouse.Aplication.Interfaces.Users;
using CCS.LittleHouse.Aplication.Services.Users;
using CCS.LittleHouse.Domain.Models.Users;
using CCS.LittleHouse.Domain.Repositories.Users;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CCS.LittleHouse.Test.Unit.Services.Users
{
    [TestFixture]
    public class UsersAppService_Register
    {
        private IMapper _mapper;
        private Mock<IUsersRepository> _repository = new Mock<IUsersRepository>();
        private Mock<IUsersManager> _usersManager = new Mock<IUsersManager>();
        private readonly string _username = "userfake";

        [SetUp]
        public void Setup()
        {
            MapperConfiguration configuration = new MapperConfiguration(conf =>
            {
                conf.AddProfile(typeof(UsersMappingProfile));
            });

            _mapper = configuration.CreateMapper();
            _repository = new Mock<IUsersRepository>();
            _usersManager = new Mock<IUsersManager>();
    }

        [Test]
        public void Register_RunTransaction()
        {
            // Arrange
            _repository.Setup(repo => repo.RunInTransaction(It.IsAny<Func<Task<UserDTO>>>()))
                .Returns(Task<UserDTO>.FromResult(new UserDTO()));
            IUsersAppService service = new UsersAppService(_mapper, _usersManager.Object, _repository.Object);

            // Act
            UserDTO result = service.Register(_username).Result;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void Register_NewUser()
        {
            // Arrange
            User user = User.Create(_username);
            _usersManager.Setup(manager => manager.CreateUser(It.Is<string>(name => name.Equals(_username))))
                .Returns(user);
            _repository.Setup(repo => repo.RunInTransaction(It.IsAny<Func<Task<UserDTO>>>()))
                .Returns((Func<Task<UserDTO>> action) => action());
            IUsersAppService service = new UsersAppService(_mapper, _usersManager.Object, _repository.Object);

            // Act
            Task<UserDTO> task = service.Register(_username);

            // Assert
            Assert.IsNotNull(task.Result);
            Assert.AreEqual(task.Result.Id, user.Id);
            Assert.AreEqual(task.Result.Name, user.Name);
        }

        [Test]
        public void Register_ExistingUser()
        {
            // Arrange
            _usersManager.Setup(manager => manager.CreateUser(It.IsAny<string>()))
                .Throws<ExistingUserException>();
            _repository.Setup(repo => repo.RunInTransaction(It.IsAny<Func<Task<UserDTO>>>()))
                .Returns((Func<Task<UserDTO>> action) => action());
            IUsersAppService service = new UsersAppService(_mapper, _usersManager.Object, _repository.Object);

            // Act y Assert
            Assert.ThrowsAsync<ExistingResourceException>(async () => await service.Register(_username));
        }

        [Test]
        public void Register_NullName()
        {
            // Arrange
            _usersManager.Setup(manager => manager.CreateUser(It.IsAny<string>()))
                .Throws<NullUserNameException>();
            _repository.Setup(repo => repo.RunInTransaction(It.IsAny<Func<Task<UserDTO>>>()))
                .Returns((Func<Task<UserDTO>> action) => action());
            IUsersAppService service = new UsersAppService(_mapper, _usersManager.Object, _repository.Object);

            // Act y Assert
            Assert.ThrowsAsync<InvalidArgumentException>(async () => await service.Register(_username));
        }

        [Test]
        public void Register_ShortName()
        {
            // Arrange
            _usersManager.Setup(manager => manager.CreateUser(It.IsAny<string>()))
                .Throws<LengthUserNameException>();
            _repository.Setup(repo => repo.RunInTransaction(It.IsAny<Func<Task<UserDTO>>>()))
                .Returns((Func<Task<UserDTO>> action) => action());
            IUsersAppService service = new UsersAppService(_mapper, _usersManager.Object, _repository.Object);

            // Act y Assert
            Assert.ThrowsAsync<InvalidArgumentException>(async () => await service.Register(_username));
        }
    }
}
