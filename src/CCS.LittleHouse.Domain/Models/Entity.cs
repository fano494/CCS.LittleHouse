using System;

namespace CCS.LittleHouse.Domain.Models
{
    public abstract class Entity
    {
        public virtual Guid Id { get; protected set; }
        public virtual DateTime CreateDateTime { get; protected set; }
        public virtual DateTime EditDateTime { get; protected set; }

        public Entity()
        {
            Id = Guid.NewGuid();
            CreateDateTime = DateTime.Now;
            EditDateTime = DateTime.Now;
        }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (compareTo is null) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return GetType().Name + " [Id=" + Id + "]";
        }

        protected void UpdateEditDateTime()
        {
            EditDateTime = DateTime.Now;
        }
    }
}
