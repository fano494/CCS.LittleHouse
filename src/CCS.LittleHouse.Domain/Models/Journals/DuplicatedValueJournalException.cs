using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CCS.LittleHouse.Domain.Models.Journals
{
    public class DuplicatedValueJournalException : Exception
    {
        public DuplicatedValueJournalException() : base()
        {
        }

        public DuplicatedValueJournalException(string message) : base(message)
        {
        }

        public DuplicatedValueJournalException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DuplicatedValueJournalException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
