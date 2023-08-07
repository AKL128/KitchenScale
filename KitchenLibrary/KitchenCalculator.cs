using System.Diagnostics;

namespace KitchenLibrary
{
    public static class KitchenCalculator
    {
        /*public string fractionInput { get; set; }
        public int resizeScale { get; set; }

        public KitchenCalculator(string fractionI, int resizeS)
        {
            fractionInput = fractionI;
            resizeScale = resizeS;
        }*/
        public static string getResized(string input, int scale)
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

        public static string unitStandard(string input)
        {
            string unit = input.Trim().ToLower();
            if (unit == "teaspoon" || unit == "teaspoons" || unit == "tsp")
            {
                return "tsp";
            }

            if (unit == "tablespoon" || unit == "tablespoons" || unit == "tbsp")
            {
                return "Tbsp";
            }

            if (unit == "cup" || unit == "cups")
            {
                return "cup";
            }

            if (unit == "ounce" || unit == "ounces" || unit == "oz")
            {
                return "oz";
            }

            if (unit == "stick" || unit == "sticks")
            {
                return unit.Trim().ToLower();
            }

            return "ERROR";
        }

        public static double Convert(int milliliters)
        {

            const double CUP_TO_ML = 236.5882365;


            double cups = milliliters / CUP_TO_ML;

            return cups;
        }
        public static string roundUnit(string unit)
        {

            return unit;
        }
    }
}