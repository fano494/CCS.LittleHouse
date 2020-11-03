using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CCS.LittleHouse.Aplication.Exceptions
{
    public class ExistingResourceException : Exception
    {
        public ExistingResourceException() : base()
        {
        }

        public ExistingResourceException(string message) : base(message)
        {
        }

        public ExistingResourceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ExistingResourceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
