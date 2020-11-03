using CCS.LittleHouse.Domain.Models.Users;
using CCS.LittleHouse.Test.Unit.Services.Users;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCS.LittleHouse.Test.Unit.Models.Users
{
    public class User_Create
    {
        [Test]
        public void Create_WithValue()
        {
            // Arrange
            string username = "userfake";

            // Act
            User user = UserFake.Create(username);

            // Assert
            Assert.AreEqual(user.Name, username);
        }

        [Test]
        public void Create_NullName()
        {
            // Act and Assert
            Assert.Throws<NullUserNameException>(() => UserFake.Create(null));
        }
    }
}
