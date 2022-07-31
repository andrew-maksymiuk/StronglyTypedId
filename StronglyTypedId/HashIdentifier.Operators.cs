namespace StronglyTypedId
{
    public partial struct HashIdentifier : IEquatable<HashIdentifier>, IEquatable<int>, IComparable<HashIdentifier>, IComparable<int>
    {
        public static HashIdentifier operator -(HashIdentifier value)
        {
            return new(checked(-value.Value));
        }

        public static HashIdentifier operator ++(HashIdentifier value)
        {
            return value + 1;
        }

        public static HashIdentifier operator --(HashIdentifier value)
        {
            return value - 1;
        }

        public static HashIdentifier operator +(HashIdentifier left, int right)
        {
            return new(left.Value + right);
        }

        public static HashIdentifier operator +(int left, HashIdentifier right)
        {
            return new(left + right.Value);
        }

        public static HashIdentifier operator -(HashIdentifier left, int right)
        {
            return new(left.Value - right);
        }

        public static HashIdentifier operator -(int left, HashIdentifier right)
        {
            return new(left - right.Value);
        }

        public static HashIdentifier operator *(HashIdentifier left, int right)
        {
            return new(left.Value * right);
        }

        public static HashIdentifier operator *(int left, HashIdentifier right)
        {
            return new(left * right.Value);
        }

        public static HashIdentifier operator /(HashIdentifier left, int right)
        {
            return new(left.Value / right);
        }

        public static HashIdentifier operator +(HashIdentifier left, HashIdentifier right)
        {
            return new(left.Value + right.Value);
        }

        public static HashIdentifier operator -(HashIdentifier left, HashIdentifier right)
        {
            return new(left.Value - right.Value);
        }

        public static bool operator >(HashIdentifier left, HashIdentifier right)
        {
            return left.Value > right.Value;
        }

        public static bool operator <(HashIdentifier left, HashIdentifier right)
        {
            return left.Value < right.Value;
        }

        public static bool operator >=(HashIdentifier left, HashIdentifier right)
        {
            return left.Value >= right.Value;
        }

        public static bool operator <=(HashIdentifier left, HashIdentifier right)
        {
            return left.Value <= right.Value;
        }

        public static bool operator ==(HashIdentifier left, HashIdentifier right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(HashIdentifier left, HashIdentifier right)
        {
            return !(left == right);
        }

        public static bool operator >(HashIdentifier left, int right)
        {
            return left.Value > right;
        }

        public static bool operator <(HashIdentifier left, int right)
        {
            return left.Value < right;
        }

        public static bool operator >=(HashIdentifier left, int right)
        {
            return left.Value >= right;
        }

        public static bool operator <=(HashIdentifier left, int right)
        {
            return left.Value <= right;
        }

        public static bool operator ==(HashIdentifier left, int right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(HashIdentifier left, int right)
        {
            return !(left == right);
        }

        public static bool operator >(int left, HashIdentifier right)
        {
            return left > right.Value;
        }

        public static bool operator <(int left, HashIdentifier right)
        {
            return left < right.Value;
        }

        public static bool operator >=(int left, HashIdentifier right)
        {
            return left >= right.Value;
        }

        public static bool operator <=(int left, HashIdentifier right)
        {
            return left <= right.Value;
        }

        public static bool operator ==(int left, HashIdentifier right)
        {
            return right.Equals(left);
        }

        public static bool operator !=(int left, HashIdentifier right)
        {
            return !(left == right);
        }

        public static explicit operator int(HashIdentifier value)
        {
            return value.Value;
        }

        public static explicit operator HashIdentifier(int value)
        {
            return new(value);
        }
    }
}
