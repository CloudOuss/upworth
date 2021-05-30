using NetworthDomain.Common;
using NetworthDomain.Entities;

namespace NetworthDomain.Events
{
    public class PositionPurchasedEvent : DomainEvent
    {
        public Transaction Transaction { get; }

        public PositionPurchasedEvent(Transaction transaction)
        {
            Transaction = transaction;
        }
    }
}