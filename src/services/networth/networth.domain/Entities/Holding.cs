using System;
using NetworthDomain.Common;
using NetworthDomain.Enums;
using NetworthDomain.ValueObjects;

namespace NetworthDomain.Entities
{
    public class Holding : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Ticker { get; set; }
        public double BuyPrice { get; set; }
        public int SharesNumber { get; set; }

        public HoldingDetails HoldingDetails { get; private set; }


        protected Holding()
        {

        }

        public Holding(string ticker, double buyPrice, int shareNumber)
        {
            Id = Guid.NewGuid();
            Ticker = ticker;
            BuyPrice = buyPrice;
            SharesNumber = shareNumber;
        }

        public void SetHoldingDetails()
        {

        }
    }
}