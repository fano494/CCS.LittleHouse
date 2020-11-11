using CCS.LittleHouse.Domain.Models.Journals;
using CCS.LittleHouse.Domain.Models.Users;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCS.LittleHouse.Test.Unit.Models.Journals
{
    [TestFixture]
    public class Journal_AddEntry
    {
        private User _user;

        [SetUp]
        public void Setup()
        {
            _user = User.Create("userfake");
        }

        [Test]
        public void AddEntry_NullValue()
        {
            // Arrange
            Journal journal = Journal.Create(_user);
            DateTime dateTime = journal.EditDateTime;

            // Act and Assert
            Assert.Throws<InvalidValueJournalException>(() => journal.AddEntry(null));
            Assert.AreEqual(dateTime, journal.EditDateTime);
        }

        [Test]
        public void AddEntry_ValidValue()
        {
            // Arrange
            Journal journal = Journal.Create(_user);
            Entry entry = new Entry(Interval.Morning, State.Bad);
            DateTime dateTime = journal.EditDateTime;
            
            // Act
            journal.AddEntry(entry);

            // Assert
            Assert.AreEqual(journal.Entries[0], entry);
            Assert.IsTrue(journal.EditDateTime > dateTime);
        }

        [Test]
        public void AddEntry_DuplicatedValue()
        {
            // Arrange
            Journal journal = Journal.Create(_user);
            journal.AddEntry(new Entry(Interval.Morning, State.Bad));
            Entry entry = new Entry(Interval.Morning, State.Good);
            DateTime dateTime = journal.EditDateTime;

            // Act and Assert
            Assert.Throws<DuplicatedValueJournalException>(() => journal.AddEntry(entry));
            Assert.AreEqual(journal.EditDateTime, dateTime);
        }
    }
}
