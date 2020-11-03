﻿using AutoMapper;
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
    public class UsersAppService_EditUserName
    {
        private IMapper _mapper;
        private Mock<IUsersManager> _usersManager;
        private Mock<IUsersRepository> _usersRepository;
        private readonly string _username = "userfake";

        [SetUp]
        public void Setup()
        {
            MapperConfiguration configuration = new MapperConfiguration(conf => {
                conf.AddProfile(typeof(UsersMappingProfile));
            });

            _mapper = configuration.CreateMapper();
            _usersManager = new Mock<IUsersManager>();
            _usersRepository = new Mock<IUsersRepository>();
        }

        [Test]
        public void EditUserName_RunTransaction()
        {
            // Arrange
            _usersRepository.Setup(repo => repo.RunInTransaction(It.IsAny<Func<Task>>()));
            IUsersAppService usersAppService = new UsersAppService(_mapper, _usersManager.Object, _usersRepository.Object);

            // Act and Assert
            Assert.DoesNotThrowAsync(() => usersAppService.EditUserName(new UserDTO()));
        }

        [Test]
        public void EditUserName_EditValidName()
        {
            // Arrange
            User user = new UserFake(_username);
            UserDTO userEdited = new UserDTO() { 
                Id = user.Id,
                Name = _username + "Edited"
            };
            
            _usersRepository.Setup(repo => repo.RunInTransaction(It.IsAny<Func<Task>>()))
                .Returns((Func<Task> action) => action());
            _usersManager.Setup(manager => manager.GetById(userEdited.Id))
                .Returns(user);
            _usersManager.Setup(manager => manager.EditName(user, userEdited.Name))
                .Callback(() => user = _mapper.Map<User>(userEdited));
            IUsersAppService usersAppService = new UsersAppService(_mapper, _usersManager.Object, _usersRepository.Object);

            // Act
            usersAppService.EditUserName(userEdited).Wait();

            // Assert
            Assert.AreEqual(user.Id, userEdited.Id);
            Assert.AreEqual(user.Name, userEdited.Name);
        }

        [Test]
        public void EditUserName_EditNullName()
        {
            // Arrange
            _usersRepository.Setup(repo => repo.RunInTransaction(It.IsAny<Func<Task>>()))
                .Returns((Func<Task> action) => action());
            _usersManager.Setup(manager => manager.EditName(It.IsAny<User>(), null))
                .Throws<NullUserNameException>();
            IUsersAppService usersAppService = new UsersAppService(_mapper, _usersManager.Object, _usersRepository.Object);
            
            // Act and Assert
            Assert.ThrowsAsync<InvalidArgumentException>(async () => await usersAppService.EditUserName(new UserDTO()));
        }

        [Test]
        public void EditUserName_EditExistingName()
        {
            // Arrange
            _usersRepository.Setup(repo => repo.RunInTransaction(It.IsAny<Func<Task>>()))
                .Returns((Func<Task> action) => action());
            _usersManager.Setup(manager => manager.EditName(It.IsAny<User>(), It.IsAny<string>()))
                .Throws<ExistingUserException>();
            IUsersAppService usersAppService = new UsersAppService(_mapper, _usersManager.Object, _usersRepository.Object);

            // Act and Assert
            Assert.ThrowsAsync<ExistingResourceException>(async () => await usersAppService.EditUserName(new UserDTO()));
        }
    }
}