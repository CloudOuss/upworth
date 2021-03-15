using System;
using System.Collections.Generic;
using NetworthDomain.Common;
using NetworthDomain.ValueObjects;

namespace NetworthDomain.Entities
{
    public class Holding : AuditableEntity, IHasDomainEvent
    {
        public Guid Id { get; set; }
        public string Ticker { get; set; }
        public double BuyPrice { get; set; }
        public int SharesNumber { get; set; }
        public Account Account { get; set; }
        public HoldingDetails HoldingDetails { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();

        protected Holding()
        {

        }

        public Holding(string ticker, double buyPrice, int shareNumber, DateTime? dateCreated)
        {
            Id = Guid.NewGuid();
            Ticker = ticker;
            BuyPrice = buyPrice;
            SharesNumber = shareNumber;
            Created = dateCreated ?? default;
            HoldingDetails = null;
        }
    }
}