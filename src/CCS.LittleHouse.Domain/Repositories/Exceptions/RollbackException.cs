using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CCS.LittleHouse.Domain.Repositories.Exceptions
{
    public class RollbackException : Exception
    {
        public RollbackException() : base()
        {
        }

        public RollbackException(string message) : base(message)
        {
        }

        public RollbackException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RollbackException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
