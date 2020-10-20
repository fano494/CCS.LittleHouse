using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCS.LittleHouse.Test.Unit.Models
{
    public class Entity_EqualsShould
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Equals_True()
        {
            // Arrange
            Guid entityId = Guid.NewGuid();
            EntityFake _entity = new EntityFake(entityId);
            EntityFake _entityEqual = new EntityFake(entityId);

            // Act
            bool result = _entity.Equals(_entityEqual);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Equals_False()
        {
            // Arrange
            EntityFake _entity = new EntityFake(Guid.NewGuid());
            EntityFake _entityNotEqual = new EntityFake(Guid.NewGuid());

            // Act
            bool result = _entity.Equals(_entityNotEqual);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Equals_OperationTrue()
        {
            // Arrange
            Guid entityId = Guid.NewGuid();
            EntityFake _entity = new EntityFake(entityId);
            EntityFake _entityEqual = new EntityFake(entityId);

            // Act
            bool result = _entity == _entityEqual;

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Equals_OperationFalse()
        {
            // Arrange
            EntityFake _entity = new EntityFake(Guid.NewGuid());
            EntityFake _entityNotEqual = new EntityFake(Guid.NewGuid());

            // Act
            bool result = _entity == _entityNotEqual;

            //Assert
            Assert.IsFalse(result);
        }
    }
}
