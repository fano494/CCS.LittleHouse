using CCS.LittleHouse.Domain.Models.Journals;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CCS.LittleHouse.Domain.Models.Users
{
    public class User : Entity
    {
        private IList<Journal> _journals;
        private string _name;

        protected User()
        {

        }

        protected internal static User Create(string name)
        {
            if (name is null)
                throw new NullUserNameException("The user name can't be null (Creation).");

            return new User()
            {
                _journals = new List<Journal>(),
                _name = name
            };
        }

        public virtual Journal[] Journals
        {
            get
            {
                return _journals.ToArray();
            }
            protected set
            {
                _journals = new List<Journal>(value);
            }
        }

        public virtual string Name
        {
            get
            {
                return _name;
            }
            protected set
            {
                _name = value;
            }
        }

        protected internal virtual void EditName(string name)
        {
            if (name is null)
                throw new NullUserNameException("The user name can't be null (Edition).");

            _name = name;
            UpdateEditDateTime();
        }

        public virtual void AddJournal(Journal journal)
        {
            if (_journals.Count(_journal => _journal.IsSameDayTo(journal)) == 0)
            {
                journal.SetUser(this);
                _journals.Add(journal);
                UpdateEditDateTime();
            }
            else
            {
                throw new InvalidOperationException("The journal is already in the list");
            }
        }

        public virtual void DeleteJournal(Journal value)
        {
            Journal journal = _journals.First(_journal => _journal.Equals(value));
            _journals.Remove(journal);
            UpdateEditDateTime();
        }
    }
}
