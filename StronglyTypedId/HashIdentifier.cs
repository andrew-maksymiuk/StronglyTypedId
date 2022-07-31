using HashidsNet;
using System;

namespace StronglyTypedId
{
    public partial struct HashIdentifier : IEquatable<HashIdentifier>, IEquatable<int>, IComparable<HashIdentifier>, IComparable<int>
    {
        private static readonly Hashids _hashids;

        private int _value;

        public int Value => _value;

        static HashIdentifier()
        {
            _hashids = new("QliHtOJq8j", 11, "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789");
        }

        public HashIdentifier(in int value)
        {
            _value = value;
        }
    }
}