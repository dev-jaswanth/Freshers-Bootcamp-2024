// NumberValidator.cs
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorLib
{
    public class NumberValidator : INumberValidator
    {
        public void Validate(IEnumerable<int> numbers)
        {
            var negatives = numbers.Where(n => n < 0).ToArray();
            if (negatives.Any())
            {
                throw new NegativesNotAllowedException(negatives);
            }
        }
    }
}
