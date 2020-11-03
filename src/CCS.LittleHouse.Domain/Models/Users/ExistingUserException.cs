using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CCS.LittleHouse.Domain.Models.Users
{
    public class ExistingUserException : Exception
    {
        public ExistingUserException() : base()
        {
        }

        public ExistingUserException(string message) : base(message)
        {
        }

        public ExistingUserException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ExistingUserException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
