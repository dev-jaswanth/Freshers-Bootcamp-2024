// INumberParser.cs
using System.Collections.Generic;

namespace StringCalculatorLib
{
    public interface INumberParser
    {
        IEnumerable<int> Parse(string input, IEnumerable<string> delimiters);
    }
}
