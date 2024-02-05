using System;
using Xunit;
using StringCalculatorLib;

namespace StringCalculatorLib.test
{
    public class StringCalculatorAddMethodTestSuite
    {
        [Fact]
        public void GivenEmptyString_ReturnsZero()
        {
            string input = "";
            int expected = 0;

            int actual = StringCalculator.Add(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GivenOnlyOneNumber_ReturnsThatNumber()
        {
            string input = "1";
            int expected = 1;

            int actual = StringCalculator.Add(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GivenTwoNumbers_ReturnsTheirAddition()
        {
            string input = "1,2";
            int expected = 3;

            int actual = StringCalculator.Add(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GivenMoreNumbers_ReturnsTheirAddition()
        {
            string input = "1,2,3";
            int expected = 6;

            int actual = StringCalculator.Add(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GivenNewLineAndCommaDelimiters_ReturnsSum()
        {
            string input = "1\n2,3";
            int expected = 6;

            int actual = StringCalculator.Add(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GivenCustomDelimiter_ReturnsSum()
        {
            string input = "//;\n2;3";
            int expected = 5;

            int actual = StringCalculator.Add(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GivenNumbersBiggerThan1000_AreIgnored()
        {
            string input = "1001,2";
            int expected = 2;

            int actual = StringCalculator.Add(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GivenDelimiterCanBeOfAnyLength_ReturnsSum()
        {
            string input = "//[***]\n1***2***3";
            int expected = 6;

            int actual = StringCalculator.Add(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GivenMultipleDelimiters_ReturnsSum()
        {
            string input = "//[*][%]\n1*2%3";
            int expected = 6;

            int actual = StringCalculator.Add(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GivenMultipleDelimitersCanBeOfAnyLength_ReturnsSum()
        {
            string input = "//[***][%%]\n1***2%%3";
            int expected = 6;

            int actual = StringCalculator.Add(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1,-2", "Negatives not allowed: -2")]
        [InlineData("1,-2,-3", "Negatives not allowed: -2, -3")]
        [InlineData("//[***][%%]\n1***-2%%-3", "Negatives not allowed: -2, -3")]
        public void GivenNegativeNumbers_ThrowsNegativesNotAllowedException(string input, string expectedMessage)
        {
            var exception = Assert.Throws<NegativesNotAllowedException>(() => StringCalculator.Add(input));

            Assert.Equal(expectedMessage, exception.Message);
        }
    }
}
