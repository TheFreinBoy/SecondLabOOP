using System;

namespace Name
{       
    public class Fraction
    {
        private long numerator;
        private long denominator;

        public long Numerator
        {
            get
            {
                return numerator;
            }
            set
            {
                numerator = value;
                Simplify();
            }
        }

        public long Denominator
        {
            get
            {
                return denominator;
            }
            set
            {
                if (value == 0)
                    throw new ArgumentException("Denominator cannot be zero.");

                denominator = value;
                Simplify();
            }
        }

        public Fraction(long numerator, long denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Denominator cannot be zero.");

            this.numerator = denominator < 0 ? -numerator : numerator;
            this.denominator = Math.Abs(denominator);
            Simplify();
        }

        public override string ToString()
        {
            return numerator + "/" + denominator;
        }

        public string ToStringWithIntegerPart()
        {
            long integerPart = numerator / denominator;
            if (integerPart != 0)
            {
                if (numerator < 0)
                {
                    numerator *= -1;
                }
                else if (denominator < 0)
                {
                    denominator *= -1;
                }
            }
            Fraction fractionalPart = new Fraction(numerator % denominator, denominator);

            if (numerator % denominator == 0)
            {
                return "(" + integerPart + ")";
            }
            else if (integerPart == 0)
            {
                return "(" + fractionalPart + ")";
            }
            else 
            {
                return "(" + integerPart + " " + fractionalPart + ")";
            }
        }

        public double ToDouble()
        {
            return (double)numerator / denominator;
        }

        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            long num = f1.numerator * f2.denominator + f1.denominator * f2.numerator;
            long denom = f1.denominator * f2.denominator;
            return new Fraction(num, denom);
        }

        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            long num = f1.numerator * f2.denominator - f1.denominator * f2.numerator;
            long denom = f1.denominator * f2.denominator;
            return new Fraction(num, denom);
        }

        public static Fraction operator *(Fraction f1, Fraction f2)
        {
            long num = f1.numerator * f2.numerator;
            long denom = f1.denominator * f2.denominator;
            return new Fraction(num, denom);
        }

        public static Fraction operator /(Fraction f1, Fraction f2)
        {
            if (f2.numerator == 0)
                throw new DivideByZeroException("Cannot divide by zero.");

            long num = f1.numerator * f2.denominator;
            long denom = f1.denominator * f2.numerator;
            return new Fraction(num, denom);
        }

        public static Fraction CalculateExpression1(long n)
        {
            return new Fraction(n, n + 1);
        }

        public static Fraction CalculateExpression2(long n)
        {
            return new Fraction(n + 1, 2 * n);
        }

        private void Simplify()
        {
            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }

            long gcd = GCD(Math.Abs(numerator), Math.Abs(denominator));
            numerator /= gcd;
            denominator /= gcd;
        }

        private static long GCD(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
    }
}
