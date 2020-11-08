using AutoMapper;
using CCS.LittleHouse.Aplication.AutoMapper.Users;
using CCS.LittleHouse.Aplication.DTO.Users;
using CCS.LittleHouse.Aplication.Exceptions;
using CCS.LittleHouse.Aplication.Interfaces.Users;
using CCS.LittleHouse.Aplication.Services.Users;
using CCS.LittleHouse.Application.Factories.Users;
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
                User.Create(_userFakeName)
            }.AsQueryable<User>();
        }

        [Test]
        public void Login_Found()
        {
            // Arrange
            Mock<IUsersRepository> repository = new Mock<IUsersRepository>();
            Mock<IUsersFactory> usersFactory = new Mock<IUsersFactory>();
            repository.Setup(repo => repo.GetAll).Returns(_users);

            IUsersAppService service = new UsersAppService(_mapper, usersFactory.Object, repository.Object);

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
            Mock<IUsersFactory> usersFactory = new Mock<IUsersFactory>();
            repository.Setup(repo => repo.GetAll).Returns(_users);
            IUsersAppService service = new UsersAppService(_mapper, usersFactory.Object, repository.Object);

            // Act and Assert
            Assert.Throws<ResourceNotFoundException>(() => service.Login(_userFakeName + "notfound"));
        }
    }
}
