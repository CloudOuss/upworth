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
        public double PurchasePrice { get; set; }
        public int Shares { get; set; }
        public Account Account { get; set; }
        public HoldingDetails HoldingDetails { get; private set; }
        public int CurrencyId { get; private set; }
        public Currency Currency { get; private set; }
        public double CostBasis => PurchasePrice * Shares;
        public double MarketValue { get; set; }
        public double GainLoss { get; set; }
        public double GainLossPercent { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();

        protected Holding()
        {

        }

        public Holding(string ticker, double purchasePrice, int share, Account account, DateTime? dateCreated, Currency currency)
        {
            Id = Guid.NewGuid();
            Ticker = ticker;
            PurchasePrice = purchasePrice;
            Shares = share;
            Created = dateCreated ?? default;
            HoldingDetails = null;
            Account = account;
            SetCurrency(currency);
        }

        public void SetCurrency(Currency currency)
        {
            Currency = currency;
            CurrencyId = Currency.Value;
        }

        public void SetAccountDetails(HoldingDetails details)
        {
            HoldingDetails = details;
            MarketValue = double.Parse(HoldingDetails.LatestClosePrice.Trim('$')) * Shares;
            GainLoss = MarketValue - CostBasis;
            GainLossPercent = GainLoss / CostBasis;
        }
    }
}