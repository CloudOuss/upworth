using System;
using System.Collections.Generic;
using NetworthDomain.Common;
using NetworthDomain.Enums;
using NetworthDomain.ValueObjects;

namespace NetworthDomain.Entities
{
    public class Position : AuditableEntity, IHasDomainEvent
    {
        public Guid Id { get; set; }
        public string Ticker { get; set; }
        public Account Account { get; set; }
        public PositionDetails PositionDetails { get; private set; }
        public int CurrencyId { get; private set; }
        public Currency Currency { get; private set; }
        public double AvgPurchasePrice { get; set; }
        public int Quantity { get; set; }
        public double CostBasis => AvgPurchasePrice * Quantity;
        public double MarketValue { get; private set; }
        public double GainLoss { get; private set; }
        public double GainLossPercent { get; private set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();

        protected Position()
        {

        }

        public Position(string ticker, Account account, DateTime dateCreated, Currency currency)
        {
            Id = Guid.NewGuid();
            Ticker = ticker;
            Created = dateCreated;
            Account = account;
            SetCurrency(currency);
            
            PositionDetails = null;
            AvgPurchasePrice = 0;
            Quantity = 0;
            MarketValue = 0;
            GainLoss = 0;
            GainLossPercent = 0;
        }

        public void SetCurrency(Currency currency)
        {
            Currency = currency;
            CurrencyId = Currency.Value;
        }

        public void SetPositionDetails(PositionDetails details)
        {
            PositionDetails = details;
            SetPositionPerformance(PositionDetails.LatestClosePrice);
        }

        private void SetPositionPerformance(double closePrice)
        {
            if (Quantity <= 0)
            {
                return;
            }

            MarketValue = closePrice * Quantity;
            GainLoss = MarketValue - CostBasis;
            GainLossPercent = MathUtils.Round(GainLoss / CostBasis);
        }
    }
}