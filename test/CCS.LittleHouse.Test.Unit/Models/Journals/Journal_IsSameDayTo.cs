using CCS.LittleHouse.Domain.Models.Journals;
using CCS.LittleHouse.Domain.Models.Users;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCS.LittleHouse.Test.Unit.Models.Journals
{
    [TestFixture]
    public class Journal_IsSameDayTo
    {
        private User _user;

        [SetUp]
        public void Setup()
        {
            _user = User.Create("userfake");
        }

        [Test]
        public void IsSameDayTo_WhenIsSameDate()
        {
            // Arrange
            Journal journal = Journal.Create(_user);

            // Act
            bool result = journal.IsSameDayTo(journal);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsSameDayTo_WhenIsSameDayAndDifferentHour()
        {
            // Arrange
            DateTime dateTime = new DateTime(2020, 10, 29, 2, 0, 0);
            Journal journalA = Journal.Create(_user);
            Journal journalB = Journal.Create(_user);
            journalA.GetType().GetProperty("CreateDateTime").SetValue(journalA, dateTime, null);
            journalB.GetType().GetProperty("CreateDateTime").SetValue(journalB, dateTime.AddHours(1), null);

            // Act
            bool result = journalA.IsSameDayTo(journalB);
           
            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsSameDayTo_WhenIsDifferentDay()
        {
            // Arrange
            Journal journalA = Journal.Create(_user);
            Journal journalB = Journal.Create(_user);
            journalB.GetType().GetProperty("CreateDateTime").SetValue(journalB, journalB.CreateDateTime.AddDays(1), null);

            // Act
            bool result = journalA.IsSameDayTo(journalB);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsSameDayTo_WhenIsNull()
        {
            // Arrange
            Journal journal = Journal.Create(_user);

            // Act
            bool result = journal.IsSameDayTo(null);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
