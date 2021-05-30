using NetworthDomain.Common;
using NetworthDomain.Entities;

namespace NetworthDomain.Events
{
    public class PositionSoldEvent : DomainEvent
    {
        public Transaction Transaction { get; }

        public PositionSoldEvent(Transaction transaction)
        {
            Transaction = transaction;
        }
    }
}