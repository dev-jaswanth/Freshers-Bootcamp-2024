// IDelimiterParser.cs
using System.Collections.Generic;

namespace StringCalculatorLib
{
    public interface IDelimiterParser
    {
        IEnumerable<string> GetDelimiters(string input);
        string GetNumbersString(string input);
    }
}
