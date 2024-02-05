// INumberParser.cs
using System.Collections.Generic;

namespace StringCalculatorLib
{
    public interface INumberParser
    {
        IEnumerable<int> ParseNumbers(string numbersString, IEnumerable<string> delimiters);
    }
}
