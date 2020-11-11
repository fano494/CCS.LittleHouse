using CCS.LittleHouse.Domain.Models.Users;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCS.LittleHouse.Test.Unit.Models.Users
{
    [TestFixture]
    public class User_EditName
    {
        private readonly string _userName = "userfake";

        [Test]
        public void EditName_ValidName()
        {
            // Arrange
            string userNameNew = "usernamenew";
            User user = User.Create(_userName);
            DateTime dateTime = user.EditDateTime;

            // Act
            user.EditName(userNameNew);

            // Assert
            Assert.AreEqual(user.Name, userNameNew);
            Assert.IsTrue(dateTime < user.EditDateTime);
        }

        [Test]
        public void EditName_NullName()
        {
            // Arrange
            User user = User.Create(_userName);
            DateTime dateTime = user.EditDateTime;

            // Act and Assert
            Assert.Throws<InvalidValueUserException>(() => user.EditName(null));
            Assert.AreEqual(dateTime, user.EditDateTime);
        }

        [Test]
        public void EditName_ShortName()
        {
            // Arrange
            string userNameNew = "abc";
            User user = User.Create(_userName);
            DateTime dateTime = user.EditDateTime;

            // Act and Assert
            Assert.Throws<LengthUserNameException>(() => user.EditName(userNameNew));
            Assert.AreEqual(dateTime, user.EditDateTime);
        }
    }
}
