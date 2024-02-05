// INegativeNumberChecker.cs
using System.Collections.Generic;

namespace StringCalculatorLib
{
    public interface INegativeNumberChecker
    {
        void Check(IEnumerable<int> numbers);
    }
}
