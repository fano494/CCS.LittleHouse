using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CCS.LittleHouse.Aplication.Exceptions
{
    public class InternalApplicationException : Exception
    {
        public InternalApplicationException() : base()
        {
        }

        public InternalApplicationException(string message) : base(message)
        {
        }

        public InternalApplicationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InternalApplicationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
