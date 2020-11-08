using CCS.LittleHouse.Domain.Models.Users;
using CCS.LittleHouse.Test.Unit.Services.Users;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCS.LittleHouse.Test.Unit.Models.Users
{
    [TestFixture]
    public class User_Create
    {
        [Test]
        public void Create_WithValue()
        {
            // Arrange
            string username = "userfake";

            // Act
            User user = User.Create(username);

            // Assert
            Assert.AreEqual(user.Name, username);
        }

        [Test]
        public void Create_NullName()
        {
            // Act and Assert
            Assert.Throws<NullUserNameException>(() => User.Create(null));
        }
    }
}
