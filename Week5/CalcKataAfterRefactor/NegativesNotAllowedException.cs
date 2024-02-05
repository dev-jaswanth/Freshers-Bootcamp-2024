// NegativesNotAllowedException.cs
using System;
using System.Collections.Generic;

namespace StringCalculatorLib
{
    public class NegativesNotAllowedException : Exception
    {
        public NegativesNotAllowedException(IEnumerable<int> negatives)
            : base($"Negatives not allowed: {string.Join(", ", negatives)}")
        {
        }
    }
}
