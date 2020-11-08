using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CCS.LittleHouse.Domain.Models.Users
{
    public class LengthUserNameException : Exception
    {
        public LengthUserNameException() : base()
        {
        }

        public LengthUserNameException(string message) : base(message)
        {
        }

        public LengthUserNameException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected LengthUserNameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
