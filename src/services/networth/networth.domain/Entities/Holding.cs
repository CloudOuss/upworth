using System;
using System.Collections.Generic;
using NetworthDomain.Common;
using NetworthDomain.Enums;
using NetworthDomain.ValueObjects;

namespace NetworthDomain.Entities
{
    public class Holding : AuditableEntity, IHasDomainEvent
    {
        public Guid Id { get; set; }
        public string Ticker { get; set; }
        public double BuyPrice { get; set; }
        public int SharesNumber { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();

        public HoldingDetails HoldingDetails { get; private set; }


        protected Holding()
        {

        }

        public Holding(string ticker, double buyPrice, int shareNumber, DateTime dateCreated)
        {
            Id = Guid.NewGuid();
            Ticker = ticker;
            BuyPrice = buyPrice;
            SharesNumber = shareNumber;
            Created = dateCreated;
        }



        public void SetHoldingDetails()
        {

        }
    }
}