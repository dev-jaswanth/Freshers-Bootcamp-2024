// IDelimiterService.cs
using System.Collections.Generic;

namespace StringCalculatorLib
{
    public interface IDelimiterService
    {
        IEnumerable<string> ExtractDelimiters(string input);
        string ExtractNumbersString(string input);
    }
}
