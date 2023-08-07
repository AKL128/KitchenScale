using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenLibrary
{
    public class Fraction
    {
        private int numerator;
        private int denominator;
        public Fraction(int n, int d)
        {
            this.numerator = n;
            this.denominator = d;
        }
        public int getNumerator
        {
            get { return this.numerator; }
            set { this.numerator = value; }
        }

        public int getDenominator
        {
            get { return this.denominator; }
            set
            {
                if (value == 0)
                {
                    throw new Exception("0 denominator");
                }

                this.denominator = value;
            }
        }

        public string getString()
        {
            if (numerator == 0)
            {
                return "";
            }
            if (denominator == 1)
            {
                return numerator.ToString();
            }
            else
            {
                return numerator.ToString() + "/" + denominator.ToString();
            }
        }

        public static int getGCD(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }
            else
            {
                return getGCD(b, a % b);
            }
        }

        public Fraction reduce()
        {
            int gcd = getGCD(numerator, denominator);
            return new Fraction(numerator / gcd, denominator / gcd);
        }

        public Fraction multiply(int constant)
        {
            return new Fraction(this.numerator * constant, this.denominator);
        }
    }
}
