using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorLib
{
    public static class StringCalculator
    {
        public static int Add(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }

            var delimiters = new List<string> { ",", "\n" };

            if (input.StartsWith("//"))
            {
                var customDelimiters = GetCustomDelimiters(input);
                delimiters.AddRange(customDelimiters);
                input = GetInputAfterCustomDelimiter(input);
            }

            var numbers = input
                .Split(delimiters.ToArray(), StringSplitOptions.None)
                .Select(int.Parse)
                .Where(n => n <= 1000)
                .ToArray();

            if (numbers.Any(n => n < 0))
            {
                var negatives = numbers.Where(n => n < 0);
                throw new NegativesNotAllowedException(negatives);
            }

            return numbers.Sum();
        }

        private static string GetInputAfterCustomDelimiter(string input) => input.Substring(input.IndexOf('\n') + 1);

        private static IEnumerable<string> GetCustomDelimiters(string input)
        {
            var delimiterSection = input.Substring(2, input.IndexOf('\n') - 2);
            if (delimiterSection.StartsWith("[") && delimiterSection.EndsWith("]"))
            {
                delimiterSection = delimiterSection.Trim('[', ']');
                return delimiterSection.Split(new[] { "][" }, StringSplitOptions.None);
            }
            return new List<string> { delimiterSection };
        }
    }

    public class NegativesNotAllowedException : Exception
    {
        public NegativesNotAllowedException(IEnumerable<int> negatives)
            : base($"Negatives not allowed: {string.Join(", ", negatives)}")
        {
        }
    }
}
