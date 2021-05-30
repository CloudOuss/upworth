using System;

namespace NetworthDomain.Exceptions
{
    public class MathException : Exception
    {
        public MathException(string message)
            : base(message)
        {
        }
    }
}
