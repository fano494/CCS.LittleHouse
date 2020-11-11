using System;
using System.Runtime.Serialization;

namespace CCS.LittleHouse.Domain.Models.Users
{
    [Serializable]
    public class WrongUserJournalException : Exception
    {
        public WrongUserJournalException() : base()
        {
        }

        public WrongUserJournalException(string message) : base(message)
        {
        }

        public WrongUserJournalException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected WrongUserJournalException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}