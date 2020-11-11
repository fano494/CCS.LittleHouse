using CCS.LittleHouse.Domain.Models.Journals;
using CCS.LittleHouse.Domain.Models.Users;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCS.LittleHouse.Test.Unit.Models.Journals
{
    [TestFixture]
    public class Journal_EditEntry
    {
        private User _user;

        [SetUp]
        public void Setup()
        {
            _user = User.Create("userfake");
        }

        [Test]
        public void EditEntry_ValidEntry()
        {
            // Arrange
            Journal journal = Journal.Create(_user);
            journal.AddEntry(new Entry(Interval.Morning, State.Bad));
            DateTime dateTime = journal.EditDateTime;

            // Act
            journal.EditEntry(Interval.Morning, State.Good);

            // Assert
            Assert.AreEqual(journal.Entries[0].State, State.Good);
            Assert.IsTrue(journal.EditDateTime > dateTime);
        }

        [Test]
        public void EditEntry_EntryNotFound()
        {
            // Arrange
            Journal journal = Journal.Create(_user);
            DateTime dateTime = journal.EditDateTime;

            // Assert and Act
            Assert.Throws<EntryNotFoundException>(() => journal.EditEntry(Interval.Afternoon, State.None));
            Assert.AreEqual(dateTime, journal.EditDateTime);
        }
    }
}
