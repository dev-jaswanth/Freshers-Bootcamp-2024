// StringCalculator.cs
using System.Linq;

namespace StringCalculatorLib
{
    public static class StringCalculator
    {
        private static readonly IDelimiterParser delimiterParser = new DelimiterParser();
        private static readonly INumberParser numberParser = new NumberParser();
        private static readonly INumberValidator numberValidator = new NumberValidator();

        public static int Add(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }

            var delimiters = delimiterParser.GetDelimiters(input);
            var numbersString = delimiterParser.GetNumbersString(input);
            var numbers = numberParser.ParseNumbers(numbersString, delimiters);

            numberValidator.Validate(numbers);

            return numbers.Sum();
        }
    }
}
