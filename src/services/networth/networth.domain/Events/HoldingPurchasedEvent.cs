using NetworthDomain.Common;
using NetworthDomain.Entities;

namespace NetworthDomain.Events
{
    public class HoldingPurchasedEvent : DomainEvent
    {
        public HoldingPurchasedEvent(Holding holding)
        {
            Holding = holding;
        }

        public Holding Holding { get; }
    }
}