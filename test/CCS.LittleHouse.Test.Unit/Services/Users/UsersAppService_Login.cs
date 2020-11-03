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
using System.Collections.Generic;
using System.Linq;

namespace CCS.LittleHouse.Test.Unit.Services.Users
{
    [TestFixture]
    public class UsersAppService_Login
    {
        private IMapper _mapper;
        private IQueryable<User> _users;
        private readonly string _userFakeName = "userfake";

        [SetUp]
        public void Setup()
        {
            MapperConfiguration config = new MapperConfiguration(opts =>
            {
                opts.AddProfile(typeof(UsersMappingProfile));
            });

            _mapper = config.CreateMapper();
            _users = new List<User>() {
                new UserFake(_userFakeName)
            }.AsQueryable<User>();
        }

        [Test]
        public void Login_Found()
        {
            // Arrange
            Mock<IUsersRepository> repository = new Mock<IUsersRepository>();
            Mock<IUsersManager> usersManager = new Mock<IUsersManager>();
            usersManager.Setup(manager => manager.GetAll).Returns(_users);

            IUsersAppService service = new UsersAppService(_mapper, usersManager.Object, repository.Object);

            // Act
            UserDTO result = service.Login(_userFakeName);

            // Assert
            Assert.AreEqual(result.Name, _userFakeName);
        }

        [Test]
        public void Login_NotFound()
        {
            // Arrange
            Mock<IUsersRepository> repository = new Mock<IUsersRepository>();
            Mock<IUsersManager> usersManager = new Mock<IUsersManager>();
            usersManager.Setup(manager => manager.GetAll).Returns(_users);
            IUsersAppService service = new UsersAppService(_mapper, usersManager.Object, repository.Object);

            // Act and Assert
            Assert.Throws<ResourceNotFoundException>(() => service.Login(_userFakeName + "notfound"));
        }
    }
}
