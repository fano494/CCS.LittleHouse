using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CCS.LittleHouse.Domain.Models.Journals
{
    public class JournalInvalidValueException : Exception
    {
        public JournalInvalidValueException() : base()
        {
        }

        public JournalInvalidValueException(string message) : base(message)
        {
        }

        public JournalInvalidValueException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected JournalInvalidValueException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
