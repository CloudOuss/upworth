using System;
using NetworthDomain.Exceptions;

namespace NetworthDomain.Common
{
    public static class MathUtils
    {
        public static double Round(double value, int precision = 2)
        {
            return Math.Round(value, precision);
        }

        public static double DoubleParse(string stringValue, int precision = 2)
        {
            bool success = double.TryParse(TrimToNumber(stringValue), out double number);
            if (success)
            {
                return Round(number, precision);
            }

            throw new MathException($"Attempted conversion of {stringValue} failed.");
        }

        public static string TrimToNumber(string stringValue)
        {
            return stringValue.Trim('$').Trim('%');
        }
    }
}
