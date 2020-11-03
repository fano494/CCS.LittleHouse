using CCS.LittleHouse.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CCS.LittleHouse.Domain.Models.Journals
{
    public class Journal : Entity
    {
        private IList<Entry> _entries;

        public virtual User User { get; protected set; }

        public virtual Entry[] Entries
        {
            get
            {
                return _entries.ToArray();
            }
            protected set
            {
                _entries = new List<Entry>(value);
            }
        }

        public Journal()
        {
            _entries = new List<Entry>();
            User = null;
        }

        public virtual bool IsSameDayTo(Journal journal)
        {
            return this.CreateDateTime.Date.Equals(journal.CreateDateTime.Date);
        }

        public virtual void SetUser(User user)
        {
            if (user is null)
            {
                throw new JournalInvalidValueException("Null user value is not valid.");
            }
            else
            {
                if (User is null)
                {
                    User = user;
                    UpdateEditDateTime();
                }
                else
                {
                    throw new JournalAssignedException("The journal has a user yet.");
                }
            }
        }

        public virtual void AddEntry(Entry entry)
        {
            if (_entries.Count(_entry => _entry.Interval == entry.Interval) == 0)
            {
                entry.SetJournal(this);
                _entries.Add(entry);
                UpdateEditDateTime();
            }
            else
            {
                throw new InvalidOperationException("The entry interval is already in the list");
            }
        }

        public virtual void EditEntry(Entry value)
        {
            Entry entry = _entries.First(_entry => _entry.Equals(value));
            entry.EditState(value.State);
            UpdateEditDateTime();
        }

        public virtual void DeleteEntry(Entry value)
        {
            Entry entry = _entries.First(_entry => _entry.Equals(value));
            _entries.Remove(entry);
            UpdateEditDateTime();
        }
    }
}
