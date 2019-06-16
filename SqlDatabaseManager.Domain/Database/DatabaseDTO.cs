using System;
using System.Collections.Generic;

namespace SqlDatabaseManager.Domain.Database
{
    public class DatabaseDTO : IEquatable<DatabaseDTO>
    {
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as DatabaseDTO);
        }

        public bool Equals(DatabaseDTO other)
        {
            return other != null &&
                   Name == other.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }
    }
}