using System.Diagnostics;

namespace KitchenLibrary
{
    public class KitchenCalculator
    {
        public string fractionInput { get; set; }
        public int resizeScale { get; set; }

        public fractionScale
        public string fractionScale(string input, int scale)
        {
            int wholeNumber = 0;
            string fraction;
            int numerator;
            int denominator;
            string? result = "";

            bool hasWholeNumber = false;

            hasWholeNumber = input.Split(" ").Length > 1;

            fraction = input;

            if (hasWholeNumber == true)
            {
                wholeNumber = int.Parse(input.Split(" ")[0]);
                wholeNumber = wholeNumber * scale;
                fraction = input.Split(" ")[1];
            }

            numerator = int.Parse(fraction.Split("/")[0]);

            denominator = int.Parse(fraction.Split("/")[1]);


            numerator = numerator * scale;

            Fraction fraction1 = new Fraction(numerator, denominator);
            if (numerator >= denominator)
            {
                wholeNumber += numerator / denominator;
            }

            int quotient = fraction1.getNumerator / fraction1.getDenominator;
            Debug.WriteLine("Q: " + quotient);
            int remainder = fraction1.getNumerator - fraction1.getDenominator * quotient;
            Debug.WriteLine(fraction1.getNumerator + "-" + fraction1.getDenominator + "*" + quotient);
            fraction1 = new Fraction(remainder, denominator);

            fraction1 = fraction1.reduce();

            Debug.WriteLine($"{fraction1.getNumerator} / {fraction1.getDenominator}");
            if (wholeNumber == 0)
            {
                return result = fraction1.getString();
            }
            else
            {
                result = wholeNumber.ToString();
                result += " " + fraction1.getString();
                return result;
            }

        }
    }
}