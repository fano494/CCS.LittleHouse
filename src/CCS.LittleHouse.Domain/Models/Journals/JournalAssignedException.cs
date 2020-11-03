using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CCS.LittleHouse.Domain.Models.Journals
{
    public class JournalAssignedException : Exception
    {
        public JournalAssignedException() : base()
        {
        }

        public JournalAssignedException(string message) : base(message)
        {
        }

        public JournalAssignedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected JournalAssignedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
