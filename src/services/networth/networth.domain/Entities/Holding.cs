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
        public double PurchasePrice { get; set; }
        public int Shares { get; set; }
        public Account Account { get; set; }
        public HoldingDetails HoldingDetails { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();

        protected Holding()
        {

        }

        public Holding(string ticker, double purchasePrice, int share, Account account, DateTime? dateCreated)
        {
            Id = Guid.NewGuid();
            Ticker = ticker;
            PurchasePrice = purchasePrice;
            Shares = share;
            Created = dateCreated ?? default;
            HoldingDetails = null;
            Account = account;
        }

        public void SetAccount()
        {

        }
    }
}