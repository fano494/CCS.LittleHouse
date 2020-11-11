using CCS.LittleHouse.Domain.Models.Journals;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CCS.LittleHouse.Domain.Models.Users
{
    public class User : Entity
    {
        private string _name;
        private IList<Journal> _journals;
        private static readonly uint _nameLengthMin = 4;

        private User()
        {
            _journals = new List<Journal>();
        }

        public static User Create(string name)
        {
            User user = new User();
            user.EditName(name);
            return user;
        }

        public virtual Journal[] Journals => _journals.ToArray();

        public virtual string Name => _name;
        
        public virtual void EditName(string name)
        {
            if (name is null)
            {
                throw new InvalidValueUserException("The user name can't be null (Edition).");
            }
            else
            {
                if (name.Length >= _nameLengthMin)
                {
                    _name = name;
                    UpdateEditDateTime();
                }
                else
                {
                    throw new LengthUserNameException($"The user name must be more length or equal than {_nameLengthMin}.");
                }
            }
        }

        public virtual void AddJournal(Journal journal)
        {
            if(journal is null)
            {
                throw new InvalidValueUserException("The journal can't be null (Add).");
            }
            else
            {
                if (_journals.Count(_journal => _journal.IsSameDayTo(journal)) == 0)
                {
                    if (journal.User.Equals(this))
                    {
                        _journals.Add(journal);
                        UpdateEditDateTime();
                    }
                    else
                    {
                        throw new WrongUserJournalException("The journal user is not this user.");
                    }
                }
                else
                {
                    throw new InvalidValueUserException("The journal is already in the list.");
                }
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
