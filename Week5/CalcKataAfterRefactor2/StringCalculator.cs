// StringCalculator.cs
using System.Linq;

namespace StringCalculatorLib
{
    public static class StringCalculator
    {
        private static readonly IDelimiterService delimiterService;
        private static readonly INumberParser numberParser;
        private static readonly INegativeNumberChecker negativeNumberChecker;

        static StringCalculator()
        {
            delimiterService = new DelimiterService();
            numberParser = new NumberParser();
            negativeNumberChecker = new NegativeNumberChecker();
        }

        public static int Add(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }

            var delimiters = delimiterService.ExtractDelimiters(input);
            var numbersString = delimiterService.ExtractNumbersString(input);
            var numbers = numberParser.Parse(numbersString, delimiters);

            negativeNumberChecker.Check(numbers);

            return numbers.Sum();
        }
    }
}
