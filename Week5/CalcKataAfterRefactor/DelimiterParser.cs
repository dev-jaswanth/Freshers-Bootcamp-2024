// DelimiterParser.cs
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorLib
{
    public class DelimiterParser : IDelimiterParser
    {
        public IEnumerable<string> GetDelimiters(string input)
        {
            if (!input.StartsWith("//")) return new[] { ",", "\n" };

            var delimiterSection = input.Substring(2, input.IndexOf('\n') - 2);
            if (delimiterSection.StartsWith("[") && delimiterSection.EndsWith("]"))
            {
                delimiterSection = delimiterSection.Trim('[', ']');
                return delimiterSection.Split(new[] { "][" }, StringSplitOptions.None);
            }
            return new[] { delimiterSection };
        }

        public string GetNumbersString(string input) =>
            input.StartsWith("//") ? input.Substring(input.IndexOf('\n') + 1) : input;
    }
}
