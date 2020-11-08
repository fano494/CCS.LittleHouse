using CCS.LittleHouse.Domain.Models.Users;
using CCS.LittleHouse.Domain.Repositories.Users;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCS.LittleHouse.Test.Unit.Models.Users
{
    [TestFixture]
    public class UsersManager_CreateUser
    {
        private readonly string _username = "userfake";

        [Test]
        public void CreateUser_NewName()
        {
            // Arrange
            Mock<IUsersRepository> repository = new Mock<IUsersRepository>();
            repository.Setup(repo => repo.IsNameUnique(It.Is<string>(name => name.Equals(_username)))).Returns(true);
            IUsersManager usersManager = new UsersManager(repository.Object);

            // Act
            User result = usersManager.CreateUser(_username);

            // Assert
            Assert.AreEqual(_username, result.Name);
        }

        [Test]
        public void CreateUser_ExistingName()
        {
            // Arrange
            Mock<IUsersRepository> repository = new Mock<IUsersRepository>();
            repository.Setup(repo => repo.IsNameUnique(It.IsAny<string>())).Returns(false);
            IUsersManager usersManager = new UsersManager(repository.Object);

            // Act and Assert
            Assert.Throws<ExistingUserException>(() => usersManager.CreateUser(_username));
        }

        [Test]
        public void CreateUser_NullName()
        {
            // Arrange
            Mock<IUsersRepository> repository = new Mock<IUsersRepository>();
            repository.Setup(repo => repo.IsNameUnique(It.IsAny<string>())).Returns(true);
            IUsersManager usersManager = new UsersManager(repository.Object);

            // Act and Assert
            Assert.Throws<NullUserNameException>(() => usersManager.CreateUser(null));
        }
    }
}
