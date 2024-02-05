// INumberValidator.cs
using System.Collections.Generic;

namespace StringCalculatorLib
{
    public interface INumberValidator
    {
        void Validate(IEnumerable<int> numbers);
    }
}
