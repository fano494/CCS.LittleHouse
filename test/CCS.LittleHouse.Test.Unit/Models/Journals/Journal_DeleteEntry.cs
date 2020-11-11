using CCS.LittleHouse.Domain.Models.Journals;
using CCS.LittleHouse.Domain.Models.Users;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCS.LittleHouse.Test.Unit.Models.Journals
{
    [TestFixture]
    public class Journal_DeleteEntry
    {
        private User _user;

        [SetUp]
        public void Setup()
        {
            _user = User.Create("userfake");
        }

        [Test]
        public void DeleteEntry_ValidEntry()
        {
            // Arrange
            Entry entry = new Entry(Interval.Morning, State.Bad);
            Journal journal = Journal.Create(_user);
            journal.AddEntry(entry);
            DateTime dateTime = journal.EditDateTime;

            // Act
            journal.DeleteEntry(Interval.Morning);

            // Assert
            Assert.IsEmpty(journal.Entries);
            Assert.Less(dateTime, journal.EditDateTime);
        }

        [Test]
        public void DeleteEntry_EntryNotFound()
        {
            // Arrange
            Journal journal = Journal.Create(_user);
            DateTime dateTime = journal.EditDateTime;

            // Act and Assert
            Assert.Throws<EntryNotFoundException>(() => journal.DeleteEntry(Interval.Afternoon));
            Assert.AreEqual(dateTime, journal.EditDateTime);
        }
    }
}
