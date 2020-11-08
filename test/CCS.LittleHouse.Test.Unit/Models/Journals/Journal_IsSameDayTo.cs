using CCS.LittleHouse.Domain.Models.Journals;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCS.LittleHouse.Test.Unit.Models.Journals
{
    [TestFixture]
    public class Journal_IsSameDayTo
    {
        [Test]
        public void IsSameDayTo_WhenIsSameDate()
        {
            // Arrange
            DateTime dateTime = DateTime.Now;
            Journal journalA = new JournalFake(dateTime);
            Journal journalB = new JournalFake(dateTime);

            // Act
            bool result = journalA.IsSameDayTo(journalB);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsSameDayTo_WhenIsSameDayAndDifferentHour()
        {
            // Arrange
            DateTime dateTime = new DateTime(2020, 10, 29, 2, 0, 0);
            Journal journalA = new JournalFake(dateTime);
            Journal journalB = new JournalFake(dateTime.AddHours(1));

            // Act
            bool result = journalA.IsSameDayTo(journalB);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsSameDayTo_WhenIsDifferentDay()
        {
            // Arrange
            DateTime dateTime = DateTime.Now;
            Journal journalA = new JournalFake(dateTime);
            Journal journalB = new JournalFake(dateTime.AddDays(-1));

            // Act
            bool result = journalA.IsSameDayTo(journalB);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
