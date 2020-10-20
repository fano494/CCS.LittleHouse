using CCS.LittleHouse.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCS.LittleHouse.Test.Unit.Models
{
    public class EntityFake : Entity
    {
        public EntityFake()
        {
        }

        public EntityFake(Guid guid)
        {
            Id = guid;
        }
    }
}
