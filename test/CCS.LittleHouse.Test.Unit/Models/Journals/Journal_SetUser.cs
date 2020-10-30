using CCS.LittleHouse.Domain.Models.Journals;
using CCS.LittleHouse.Domain.Models.Users;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CCS.LittleHouse.Test.Unit.Models.Journals
{
    [TestFixture]
    public class Journal_SetUser
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void SetUser_SetNullValue()
        {
            // Arrange
            Journal journal = new Journal();
            User user = null;
            DateTime editDate = journal.EditDateTime;

            // Act and Assert
            Assert.Throws<JournalInvalidValueException>(() => journal.SetUser(user));
            Assert.IsTrue(editDate.Equals(journal.EditDateTime));
        }

        [Test]
        public void SetUser_WhenJournalHasNotUser()
        {
            // Arrange
            Journal journal = new Journal();
            User user = new UserFake("userfake");
            DateTime editDate = journal.EditDateTime;

            // Act 
            journal.SetUser(user);
            
            // Assert
            Assert.AreEqual(journal.User, user);
            Assert.IsTrue(editDate < journal.EditDateTime);
        }

        [Test]
        public void SetUser_WhenJournalHasUser()
        {
            // Arrange
            User userJournal = new UserFake("userjournal");
            Journal journal = new JournalFake(userJournal);
            User user = new UserFake("userfake");
            DateTime editDate = journal.EditDateTime;

            // Act and Assert
            Assert.Throws<JournalAssignedException>(() => journal.SetUser(user));
            Assert.IsTrue(editDate.Equals(journal.EditDateTime));
            Assert.AreEqual(userJournal, journal.User);
        }
    }
}
