using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CCS.LittleHouse.Domain.Models.Journals
{
    public class EntryNotFoundException : Exception
    {
        public EntryNotFoundException() : base()
        {
        }

        public EntryNotFoundException(string message) : base(message)
        {
        }

        public EntryNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EntryNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
