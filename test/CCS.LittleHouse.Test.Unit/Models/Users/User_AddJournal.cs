using CCS.LittleHouse.Domain.Models.Journals;
using CCS.LittleHouse.Domain.Models.Users;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCS.LittleHouse.Test.Unit.Models.Users
{
    [TestFixture]
    public class User_AddJournal
    {
        [Test]
        public void AddJournal_NullJournal()
        {
            // Arrange
            User user = User.Create("userfake");
            DateTime dateTime = user.EditDateTime;

            // Act and Assert
            Assert.Throws<InvalidValueUserException>(() => user.AddJournal(null));
            Assert.AreEqual(dateTime, user.EditDateTime);
        }

        [Test]
        public void AddJournal_ValidJournal()
        {
            // Arrange
            User user = User.Create("userfake");
            Journal journal = Journal.Create(user);
            DateTime dateTime = user.EditDateTime;

            // Act
            user.AddJournal(journal);

            // Assert
            Assert.AreEqual(user.Journals[0], journal);
            Assert.Less(dateTime, user.EditDateTime);
        }

        [Test]
        public void AddJournal_JournalUserIncorrect()
        {
            // Arrange
            User user = User.Create("userfake");
            User otherUser = User.Create("otheruser");
            Journal journal = Journal.Create(otherUser);
            DateTime dateTime = user.EditDateTime;

            // Act and Assert
            Assert.Throws<InvalidValueJournalException>(() => user.AddJournal(journal));
            Assert.AreEqual(dateTime, user.EditDateTime);
        }
    }
}
