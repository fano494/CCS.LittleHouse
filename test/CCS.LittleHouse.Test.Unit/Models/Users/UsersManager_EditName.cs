using CCS.LittleHouse.Domain.Models.Users;
using CCS.LittleHouse.Domain.Repositories.Users;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CCS.LittleHouse.Test.Unit.Models.Users
{
    public class UsersManager_EditName
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void EditName_NewName()
        {
            // Arrange
            User user = new UserFake("userfake");
            Mock<IUsersRepository> usersRepository = new Mock<IUsersRepository>();
            usersRepository.Setup(mock => mock.IsNameUnique(It.IsAny<string>())).Returns(true);
            IUsersManager usersManager = new UsersManager(usersRepository.Object);

            // Act
            usersManager.EditName(user, "newname");

            // Assert
            Assert.AreEqual(user.Name, "newname");
        }

        [Test]
        public void EditName_ExistingName()
        {

        }
    }
}
