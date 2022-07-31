namespace StronglyTypedId
{
    public partial struct HashIdentifier : IEquatable<HashIdentifier>, IEquatable<int>, IComparable<HashIdentifier>, IComparable<int>
    {
        public void Set(in int value)
        {
            _value = value;
        }

        public override string ToString()
        {
            return Print();
        }

        public string Print()
        {
            return _hashids.Encode(Value);
        }

        public static HashIdentifier Parse(in string value)
        {
            if (TryParse(value, out HashIdentifier _result))
                return _result;
            throw new FormatException(value);
        }

        public static bool TryParse(in string value, out HashIdentifier result)
        {
            int[] _decode = _hashids.Decode(value);

            if (_decode.Length == 0)
            {
                result = default;
                return false;
            }
            result = new(_decode[0]);
            return true;
        }

        public int CompareTo(HashIdentifier other)
        {
            return CompareTo(other.Value);
        }

        public int CompareTo(int other)
        {
            return Value.CompareTo(other);
        }

        public override bool Equals(object obj)
        {
            switch (obj)
            {
                case int _a: return Equals(_a);
                case HashIdentifier _a: return Equals(_a);
            }
            return false;
        }

        public bool Equals(int other)
        {
            return other == Value;
        }

        public bool Equals(HashIdentifier other)
        {
            return other.Value == Value;
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }
    }
}