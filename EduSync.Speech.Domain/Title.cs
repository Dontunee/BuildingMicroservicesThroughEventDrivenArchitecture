using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace EduSync.Speech.Domain
{
    public class Title : IEquatable<Title>
    {
        private const int minLength = 10;
        private const int maxLength = 60;

        public string Value { get; private set; }

        public Title(string value)
        {
            if (value.Length < minLength)
                throw new InvalidLengthAggregateException("Value is too short");

            if (value.Length > maxLength)
                throw new InvalidLengthAggregateException("Value is too long");

            Value = value;
        }

        [Serializable]
        public class InvalidLengthAggregateException : Exception
        {
            public InvalidLengthAggregateException()
            {

            }

            public InvalidLengthAggregateException(string message)
                : base(message)
            {

            }

        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Title);
        }

        public bool Equals([AllowNull] Title other)
        {
            return other != null &&
                   Value == other.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }

        public static bool operator ==(Title left, Title right)
        {
            return EqualityComparer<Title>.Default.Equals(left, right);
        }

        public static bool operator !=(Title left, Title right)
        {
            return !(left == right);
        }
    }
}
