using CCS.LittleHouse.Domain.Models.Users;
using CCS.LittleHouse.Domain.Repositories.Exceptions;
using CCS.LittleHouse.Domain.Repositories.Users;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCS.LittleHouse.Test.Unit.Models.Users
{
    [TestFixture]
    public class UsersManager_GetById
    {
        [Test]
        public void GetById_Found()
        {
            // Arrange
            User user = new UserFake("userfake");
            Mock<IUsersRepository> repository = new Mock<IUsersRepository>();
            repository.Setup(repo => repo.GetById(It.IsAny<Guid>())).Returns(user);
            IUsersManager usersManager = new UsersManager(repository.Object);

            // Act
            User result = usersManager.GetById(user.Id);

            // Assert
            Assert.AreEqual(result, user);
        }

        [Test]
        public void GetById_NotFound()
        {
            // Arrange
            Mock<IUsersRepository> repository = new Mock<IUsersRepository>();
            repository.Setup(repo => repo.GetById(It.IsAny<Guid>())).Throws(new EntityNotFoundException());
            IUsersManager usersManager = new UsersManager(repository.Object);

            // Act and Assert
            Assert.Throws<EntityNotFoundException>(() => usersManager.GetById(Guid.NewGuid()));
        }
    }
}
