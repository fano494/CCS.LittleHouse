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
    [TestFixture]
    public class UsersManager_EditName
    {
        private User _user;
        private Mock<IUsersRepository> _usersRepository;
        private readonly string _userName = "userfake";
        private readonly string _userNewName = "usernewname";

        [SetUp]
        public void Setup()
        {
            _user = User.Create(_userName);
            _usersRepository = new Mock<IUsersRepository>();
        }

        [Test]
        public void EditName_NewName()
        {
            // Arrange
            _usersRepository.Setup(mock => mock.IsNameUnique(It.IsAny<string>()))
                .Returns(true);
            IUsersManager usersManager = new UsersManager(_usersRepository.Object);
            DateTime editDate = _user.EditDateTime;

            // Act
            usersManager.EditName(_user, _userNewName);

            // Assert
            Assert.AreEqual(_user.Name, _userNewName);
            Assert.IsTrue(editDate < _user.EditDateTime);
        }

        [Test]
        public void EditName_ExistingName()
        {
            // Arrange
            _usersRepository.Setup(mock => mock.IsNameUnique(It.IsAny<string>()))
                .Returns(false);
            IUsersManager usersManager = new UsersManager(_usersRepository.Object);
            DateTime editDate = _user.EditDateTime;

            // Act and Assert
            Assert.Throws<ExistingUserException>(() => usersManager.EditName(_user, _userNewName));
            Assert.AreEqual(_user.Name, _userName);
            Assert.AreEqual(editDate, _user.EditDateTime);
        }

        [Test]
        public void EditName_NullName()
        {
            // Arrange
            _usersRepository.Setup(mock => mock.IsNameUnique(It.IsAny<string>()))
                .Returns(true);
            IUsersManager usersManager = new UsersManager(_usersRepository.Object);
            DateTime editDate = _user.EditDateTime;

            // Act and Assert
            Assert.Throws<NullUserNameException>(() => usersManager.EditName(_user, null));
            Assert.AreEqual(_user.Name, _userName);
            Assert.AreEqual(editDate, _user.EditDateTime);
        }

        [Test]
        public void EditName_ShortName()
        {
            // Arrange
            _usersRepository.Setup(mock => mock.IsNameUnique(It.IsAny<string>()))
                .Returns(true);
            IUsersManager usersManager = new UsersManager(_usersRepository.Object);
            DateTime editDate = _user.EditDateTime;

            // Act and Assert
            Assert.Throws<LengthUserNameException>(() => usersManager.EditName(_user, "abc"));
            Assert.AreEqual(_user.Name, _userName);
            Assert.AreEqual(editDate, _user.EditDateTime);
        }
    }
}
