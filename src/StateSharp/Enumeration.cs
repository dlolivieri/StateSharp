using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace StateSharp
{
    /// <summary>
    /// An Object based enumeration, to allow the StateMachine to be generic when dealing with States/Commands
    /// </summary>
    public abstract class Enumeration : IComparable
    {
        public string Name { get; private set; }

        public int Value { get; private set; }

        protected Enumeration(string name, int value)
        {    
            Name = name;
            Value = value;
        }

        public override string ToString()
        {
            return Name;
        }

        public static IEnumerable<T> GetAll<T>() where T : Enumeration
        {
            var fields = typeof(T).GetFields(BindingFlags.Public |  BindingFlags.Static | BindingFlags.DeclaredOnly);
            IEnumerable<T> all = fields.Select(f => f.GetValue(null)).Cast<T>();

            return all;
        }

        public override bool Equals(object obj)
        {
            var other = obj as Enumeration;

            if (other == null)
                return false;

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Value.Equals(other.Value);

            var isMatch = typeMatches && valueMatches;

            return isMatch;
        }

        public int CompareTo(object obj) 
        {
            _ = obj ?? throw new ArgumentNullException(nameof(obj));

            Enumeration other = obj as Enumeration ?? throw new ArgumentException($"{nameof(obj)} is not an Enumeration type");
            int comparison = Value.CompareTo(other.Value);

            return comparison; 
        }

        public override int GetHashCode()
        {
            int hash = 17;
            int hashFactor = 23;

            hash = hash * hashFactor + Name.GetHashCode();
            hash = hash * hashFactor + Value.GetHashCode();

            return hash;
        }
    }
}
