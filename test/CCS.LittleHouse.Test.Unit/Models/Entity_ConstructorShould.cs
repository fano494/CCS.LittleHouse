using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCS.LittleHouse.Test.Unit.Models
{
    [TestFixture]
    public class Entity_ConstructorShould
    {
        [Test]
        public void Constructor_NewGuid()
        {
            // Arrange
            EntityFake _entity = new EntityFake();
            // Act
            bool result = _entity.Id.Equals(Guid.Empty);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Constructor_CreateDateTimeValid()
        {
            // Arrange
            DateTime beforeDateTime = DateTime.Now;
            EntityFake _entity = new EntityFake();
            DateTime afterDateTime = DateTime.Now;
            // Act
            bool resultBefore = _entity.CreateDateTime.CompareTo(beforeDateTime) > 0;
            bool resultAfter = _entity.CreateDateTime.CompareTo(afterDateTime) < 0;

            //Assert
            Assert.IsTrue(resultBefore && resultAfter);
        }

        [Test]
        public void Constructor_EditDateTimeValid()
        {
            // Arrange
            DateTime beforeDateTime = DateTime.Now;
            EntityFake _entity = new EntityFake();
            DateTime afterDateTime = DateTime.Now;
            // Act
            bool resultBefore = _entity.EditDateTime.CompareTo(beforeDateTime) > 0;
            bool resultAfter = _entity.EditDateTime.CompareTo(afterDateTime) < 0;

            //Assert
            Assert.IsTrue(resultBefore && resultAfter);
        }
    }
}
