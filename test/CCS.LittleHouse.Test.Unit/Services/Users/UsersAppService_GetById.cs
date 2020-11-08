using AutoMapper;
using CCS.LittleHouse.Aplication.AutoMapper.Users;
using CCS.LittleHouse.Aplication.DTO.Users;
using CCS.LittleHouse.Aplication.Exceptions;
using CCS.LittleHouse.Aplication.Interfaces.Users;
using CCS.LittleHouse.Aplication.Services.Users;
using CCS.LittleHouse.Application.Factories.Users;
using CCS.LittleHouse.Domain.Models.Users;
using CCS.LittleHouse.Domain.Repositories.Exceptions;
using CCS.LittleHouse.Domain.Repositories.Users;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCS.LittleHouse.Test.Unit.Services.Users
{
    [TestFixture]
    public class UsersAppService_GetById
    {
        private IMapper _mapper;

        [SetUp]
        public void Setup()
        {
            MapperConfiguration config = new MapperConfiguration(opts =>
            {
                opts.AddProfile(typeof(UsersMappingProfile));
            });

            _mapper = config.CreateMapper();
        }

        [Test]
        public void GetById_Found()
        {
            // Arrange
            Mock<IUsersRepository> repository = new Mock<IUsersRepository>();
            User user = User.Create("userfake");
            Mock<IUsersFactory> usersFactory = new Mock<IUsersFactory>();
            repository.Setup(repo => repo.GetById(It.IsAny<Guid>())).Returns(user);
            IUsersAppService service = new UsersAppService(_mapper, usersFactory.Object, repository.Object);

            // Act
            UserDTO result = service.GetById(user.Id);

            // Assert
            Assert.AreEqual(result.Id, user.Id);
        }

        
        [Test]
        public void GetById_NotFound()
        {
            // Arrange
            Mock<IUsersRepository> repository = new Mock<IUsersRepository>();
            Mock<IUsersFactory> usersFactory = new Mock<IUsersFactory>();
            repository.Setup(repo => repo.GetById(It.IsAny<Guid>())).Throws(new EntityNotFoundException());
            IUsersAppService service = new UsersAppService(_mapper, usersFactory.Object, repository.Object);

            // Act and Assert
            Assert.Throws<ResourceNotFoundException>(() => service.GetById(Guid.NewGuid()));
        }
        
    }
}
