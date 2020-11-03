using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CCS.LittleHouse.Domain.Models.Users
{
    public class NullUserNameException : Exception
    {
        public NullUserNameException() : base()
        {
        }

        public NullUserNameException(string message) : base(message)
        {
        }

        public NullUserNameException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NullUserNameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
