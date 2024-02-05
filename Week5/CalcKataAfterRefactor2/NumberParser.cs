// NumberParser.cs
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorLib
{
    public class NumberParser : INumberParser
    {
        public IEnumerable<int> Parse(string input, IEnumerable<string> delimiters) =>
            input.Split(delimiters.ToArray(), StringSplitOptions.None)
                 .Select(int.Parse)
                 .Where(n => n <= 1000);
    }
}
