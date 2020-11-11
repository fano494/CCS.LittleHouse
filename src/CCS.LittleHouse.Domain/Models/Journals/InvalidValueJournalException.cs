using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CCS.LittleHouse.Domain.Models.Journals
{
    public class InvalidValueJournalException : Exception
    {
        public InvalidValueJournalException() : base()
        {
        }

        public InvalidValueJournalException(string message) : base(message)
        {
        }

        public InvalidValueJournalException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidValueJournalException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
