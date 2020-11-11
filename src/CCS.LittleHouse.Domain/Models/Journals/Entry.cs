using System;

namespace CCS.LittleHouse.Domain.Models.Journals
{
    public class Entry : Entity
    {
        public virtual Interval Interval { get; protected set; }
        public virtual State State { get; protected set; }
        public virtual Journal Journal { get; protected set; }

        protected Entry()
        {

        }

        public Entry(Interval interval, State state)
        {
            Interval = interval;
            State = state;
            Journal = null;
        }

        public virtual void EditState(State value)
        {
            State = value;
            UpdateEditDateTime();
        }

        public virtual void SetJournal(Journal journal)
        {
            if (Journal is null)
            {
                Journal = journal;
                UpdateEditDateTime();
            }
            else
            {
                throw new InvalidOperationException("The entry interval has already a Journal");
            }
        }
    }
}
