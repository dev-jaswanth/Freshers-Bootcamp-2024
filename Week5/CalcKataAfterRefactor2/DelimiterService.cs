// DelimiterService.cs
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorLib
{
    public class DelimiterService : IDelimiterService
    {
        public IEnumerable<string> ExtractDelimiters(string input)
        {
            if (!input.StartsWith("//")) return new[] { ",", "\n" };

            var delimiterIndicator = input.Substring(2, input.IndexOf('\n') - 2);
            if (delimiterIndicator.StartsWith("[") && delimiterIndicator.EndsWith("]"))
            {
                delimiterIndicator = delimiterIndicator.Trim('[', ']');
                return delimiterIndicator.Split(new[] { "][" }, StringSplitOptions.None);
            }
            return new[] { delimiterIndicator };
        }

        public string ExtractNumbersString(string input) =>
            input.StartsWith("//") ? input.Substring(input.IndexOf('\n') + 1) : input;
    }
}
