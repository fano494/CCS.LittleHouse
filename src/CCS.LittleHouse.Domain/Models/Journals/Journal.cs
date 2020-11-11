using CCS.LittleHouse.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CCS.LittleHouse.Domain.Models.Journals
{
    public class Journal : Entity
    {
        private IList<Entry> _entries;
        private User _user;

        private Journal(User user)
        {
            _entries = new List<Entry>();
            _user = user;
        }

        public static Journal Create(User user) {
            if (user is null)
            {
                throw new InvalidValueJournalException("Null user value is not valid.");
            }
            else
            {
                return new Journal(user);
            }
        }

        public virtual User User => _user;

        public virtual Entry[] Entries => _entries.ToArray();

        public virtual bool IsSameDayTo(Journal journal)
        {
            if(journal is null)
            {
                return false;
            }

            return this.CreateDateTime.Date.Equals(journal.CreateDateTime.Date);
        }

        public virtual void AddEntry(Entry entry)
        {
            if (entry is null)
            {
                throw new InvalidValueJournalException("Null entry value is not valid.");
            }
            else
            {
                if (_entries.Count(_entry => _entry.Interval.Equals(entry.Interval)) == 0)
                {
                    entry.SetJournal(this);
                    _entries.Add(entry);
                    UpdateEditDateTime();
                }
                else
                {
                    throw new DuplicatedValueJournalException("The entry interval is already in the list");
                }
            }
        }

        public virtual void EditEntry(Interval interval, State state)
        {
            Entry entry = _entries.FirstOrDefault(_entry => _entry.Interval.Equals(interval));
            
            if(entry is null)
            {
                throw new EntryNotFoundException("The entry interval is not in the list.");
            }
            else
            {
                entry.EditState(state);
                UpdateEditDateTime();
            }
        }

        public virtual void DeleteEntry(Interval interval)
        {
            Entry entry = _entries.FirstOrDefault(_entry => _entry.Interval.Equals(interval));

            if (entry is null)
            {
                throw new EntryNotFoundException("The entry interval is not in the list.");   
            }
            else
            {
                _entries.Remove(entry);
                UpdateEditDateTime();
            }
        }
    }
}
