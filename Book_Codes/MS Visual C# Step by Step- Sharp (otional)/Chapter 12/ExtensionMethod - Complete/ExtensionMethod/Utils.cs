using System;

namespace Extensions
{
    static class Utils
    {
        public static int ConvertToBase(this int i, int baseToConvertTo)
        {
            if (baseToConvertTo < 2 || baseToConvertTo > 10)
            {
                throw new ArgumentException("Value cannot be converted to base " +
                    baseToConvertTo.ToString());
            }

            int result = 0;
            int iterations = 0;
            do
            {
                int nextDigit = i % baseToConvertTo;
                i /= baseToConvertTo;
                result += nextDigit * (int)Math.Pow(10, iterations);
                iterations++;
            }
            while (i != 0);
            return result;
        }
    }
}