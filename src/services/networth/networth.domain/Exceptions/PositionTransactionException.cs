using System;

namespace NetworthDomain.Exceptions
{
    public class PositionTransactionException : Exception
    {
        public PositionTransactionException(string message)
            : base(message)
        {
        }
    }
}