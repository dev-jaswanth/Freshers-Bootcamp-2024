using System.Collections.Generic;
using Xunit;
using StringCalculatorLib;

namespace StringCalculatorLib.Tests
{
    public class StringCalculatorAddMethodTestSuite
    {
        // Positive test cases
        [Theory]
        [MemberData(nameof(GetPositiveTestData))]
        public void Add_GivenVariousInputs_ReturnsExpectedResult(string input, int expected)
        {
            var result = StringCalculator.Add(input);
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> GetPositiveTestData()
        {
            yield return new object[] { "", 0 };
            yield return new object[] { "1", 1 };
            yield return new object[] { "1,2", 3 };
            yield return new object[] { "1,2,3", 6 };
            yield return new object[] { "1\n2,3", 6 };
            yield return new object[] { "//;\n2;3", 5 };
            yield return new object[] { "1001,2", 2 };
            yield return new object[] { "//[***]\n1***2***3", 6 };
            yield return new object[] { "//[*][%]\n1*2%3", 6 };
            yield return new object[] { "//[***][%%]\n1***2%%3", 6 };
        }

        // Negative test cases with expected exception message
        [Theory]
        [MemberData(nameof(GetNegativeTestData))]
        public void Add_GivenNegativeNumbers_ThrowsNegativesNotAllowedException(string input, string expectedMessage)
        {
            var exception = Assert.Throws<NegativesNotAllowedException>(() => StringCalculator.Add(input));
            Assert.Equal(expectedMessage, exception.Message);
        }

        public static IEnumerable<object[]> GetNegativeTestData()
        {
            yield return new object[] { "1,-2", "Negatives not allowed: -2" };
            yield return new object[] { "1,-2,-3", "Negatives not allowed: -2, -3" };
            yield return new object[] { "//[***][%%]\n1***-2%%-3", "Negatives not allowed: -2, -3" };
        }
    }
}
