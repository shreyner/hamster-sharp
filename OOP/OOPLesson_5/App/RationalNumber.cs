using System;

namespace App
{
    class RationalNumber : IEquatable<RationalNumber>, IComparable<RationalNumber>
    {
        private int _numerator = 0;
        private int _denominator = 0;

        public int Numerator
        {
            get { return _numerator; }
        }

        public int Denominator
        {
            get { return _denominator; }
        }

        public RationalNumber(int numerator, int denominator)
        {
            _numerator = numerator;
            _denominator = denominator;
        }

        public static RationalNumber operator ++(RationalNumber rn)
        {
            rn._numerator++;
            rn._denominator++;

            return rn;
        }

        public static RationalNumber operator --(RationalNumber rn)
        {
            rn._numerator--;
            rn._denominator--;

            return rn;
        }

        public static RationalNumber operator +(RationalNumber rn1, RationalNumber rn2)
        {
            return new RationalNumber(numerator: rn1.Numerator + rn2.Numerator,
                denominator: rn1.Denominator + rn2.Denominator);
        }

        public static RationalNumber operator -(RationalNumber rn1, RationalNumber rn2)
        {
            return new RationalNumber(numerator: rn1.Numerator - rn2.Numerator,
                denominator: rn1.Denominator - rn2.Denominator);
        }

        public static bool operator ==(RationalNumber rn1, RationalNumber rn2)
        {
            return rn1.Equals(rn2);
        }

        public static bool operator !=(RationalNumber rn1, RationalNumber rn2)
        {
            return !rn1.Equals(rn2);
        }

        public static bool operator >(RationalNumber rn1, RationalNumber rn2)
        {
            return rn1.CompareTo(rn2) != 0;
        }
        
        public static bool operator >=(RationalNumber rn1, RationalNumber rn2)
        {
            return rn1.Equals(rn2) || rn1.CompareTo(rn2) != 0;
        }
        
        public static bool operator <(RationalNumber rn1, RationalNumber rn2)
        {
            return rn2.CompareTo(rn1) != 0;
        }
        
        public static bool operator <=(RationalNumber rn1, RationalNumber rn2)
        {
            return rn2.Equals(rn1) || rn2.CompareTo(rn1) != 0;
        }

        public int CompareTo(RationalNumber? other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;

            if (this._denominator == other._denominator)
            {
                return this._numerator > other._numerator ? 1 : 0;
            }

            var thisRationalNumber = new RationalNumber(numerator: this._numerator * other._denominator, denominator: this._denominator * other._denominator);
            var otherRationalNumber = new RationalNumber(numerator: other._numerator * this._denominator,
                denominator: other._denominator * this._denominator);

            return thisRationalNumber.CompareTo(otherRationalNumber);
        }

        public bool Equals(RationalNumber other)
        {
            return _numerator == other._numerator && _denominator == other._denominator;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((RationalNumber) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_numerator, _denominator);
        }


        public override string ToString()
        {
            return $"{_numerator}/{_denominator}";
        }
    }
}
