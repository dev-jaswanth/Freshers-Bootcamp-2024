// NegativeNumberChecker.cs
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorLib
{
    public class NegativeNumberChecker : INegativeNumberChecker
    {
        public void Check(IEnumerable<int> numbers)
        {
            var negatives = numbers.Where(n => n < 0).ToArray();
            if (negatives.Any())
            {
                throw new NegativesNotAllowedException(negatives);
            }
        }
    }
}
