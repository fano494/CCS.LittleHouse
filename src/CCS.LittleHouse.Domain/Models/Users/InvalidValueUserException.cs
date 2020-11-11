using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CCS.LittleHouse.Domain.Models.Users
{
    public class InvalidValueUserException : Exception
    {
        public InvalidValueUserException() : base()
        {
        }

        public InvalidValueUserException(string message) : base(message)
        {
        }

        public InvalidValueUserException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidValueUserException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
