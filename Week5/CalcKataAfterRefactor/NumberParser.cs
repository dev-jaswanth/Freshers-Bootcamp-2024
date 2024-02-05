// NumberParser.cs
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorLib
{
    public class NumberParser : INumberParser
    {
        public IEnumerable<int> ParseNumbers(string numbersString, IEnumerable<string> delimiters) =>
            numbersString.Split(delimiters.ToArray(), StringSplitOptions.None)
                         .Select(int.Parse)
                         .Where(n => n <= 1000);
    }
}
