using KitchenLibrary;
using System;
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

        [Theory]
        [InlineData(1, 2, 1)]
        [InlineData(2, 4, 2)]
        [InlineData(3, 6, 3)]
        [InlineData(0, 0, 0)]
        [InlineData(4, 0, 4)]
        [InlineData(0, 8, 8)]
        public void GetGCD_NotNull(int fractionNumerator, int fractionDenominator, int expected)
        {
            Assert.Equal(expected, Fraction.getGCD(fractionNumerator, fractionDenominator));
        }

        [Theory]
        [MemberData(nameof(FractionTestData.GetFractionFromDataGenerator), MemberType = typeof(FractionTestData))]
        public void reduce_tests(int fractionNumerator, int fractionDenominator, Tuple<int, int> expected)
        {
            Fraction frac = new Fraction(fractionNumerator, fractionDenominator);
            frac.reduce();

            Fraction fracExpected = new Fraction(expected.Item1, expected.Item2);

        }

    }

    public class FractionTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 0, 2, ""};
            yield return new object[] { 2, 3, "2/3"};
            yield return new object[] { 2, 1, "2" };
        }

        public static IEnumerable<object[]> GetFractionFromDataGenerator()
        {
            yield return new object[]
            {
            new Fraction (0, 0),
            new Fraction (1, 2),
            new Fraction (2, 4),
            new Fraction (9, 0),
            new Fraction (0, 8),
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}