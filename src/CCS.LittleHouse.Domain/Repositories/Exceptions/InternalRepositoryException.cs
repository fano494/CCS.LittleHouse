using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CCS.LittleHouse.Domain.Repositories.Exceptions
{
    public class InternalRepositoryException : Exception
    {
        public InternalRepositoryException() : base()
        {
        }

        public InternalRepositoryException(string message) : base(message)
        {
        }

        public InternalRepositoryException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InternalRepositoryException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
