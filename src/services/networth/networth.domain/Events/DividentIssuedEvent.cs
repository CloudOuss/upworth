using NetworthDomain.Common;
using NetworthDomain.Entities;

namespace NetworthDomain.Events
{
    public class DividentIssuedEvent : DomainEvent
    {
        public Transaction Transaction { get; }

        public DividentIssuedEvent(Transaction transaction)
        {
            Transaction = transaction;
        }
    }
}