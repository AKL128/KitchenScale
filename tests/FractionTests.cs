using KitchenLibrary;
using System.Collections;

namespace tests
{
    public class FractionTests
    {
        [Theory]
        [ClassData(typeof(FractionTestData))]
        public void Fraction_Has_NumeratorAndDenominator(int fractionNumerator, int fractionDenominator, string expected)
        {
            Fraction frac = new Fraction(fractionNumerator, fractionDenominator);

            Assert.Equal(expected, frac.getString());
           
        }

        /*[Theory]
        [ClassData(typeof(FractionTestData))]
        public void GetGCD_NotNull(int fractionNumerator, int fractionDenominator, int expected)
        {

            Assert.Equal(expected, Fraction.getGCD(fractionNumerator, fractionDenominator));
        }*/

    }

    public class FractionTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 0, 2, ""};
            yield return new object[] { 2, 3, "2/3"};
            yield return new object[] { 2, 1, "2" };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}