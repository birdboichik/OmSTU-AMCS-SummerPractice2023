using Xunit;
using SquareEquationLib;

namespace SquareEquation_Test
{
    public class SquareEquation_Test
    {
        [Theory]
        [InlineData(0, 1, 1)]
        [InlineData(1, double.NaN, 1)]
        [InlineData(1, 1, double.PositiveInfinity)]
        [InlineData(double.NegativeInfinity, 1, 1)]

        public void ThrowError(double a, double b, double c)
        {
            Assert.Throws<ArgumentException>(() => SquareEquation.Solve(a, b, c));
        }

        [Theory]
        [InlineData(2, 2, 3, new double[0])]
        [InlineData(1, 2, 1, new double[1] { -1 })]
        [InlineData(1, 2, -3, new double[2] { 1, -3 })]

        public void noThrowError(double a, double b, double c, double[] expected)
        {
            var result = SquareEquation.Solve(a, b, c);
            Array.Sort(result);
            Array.Sort(expected);

            if (expected.Length != result.Length)
            {
                Assert.Fail("Amount of roots does not match");
            }

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.Equal(expected[i], result[i], 5);
            }
        }
    }
}