using System;
using System.Collections.Generic;
using NetworthDomain.Common;
using NetworthDomain.Enums;
using NetworthDomain.Events;
using NetworthDomain.Exceptions;

namespace NetworthDomain.Entities
{
    public class Transaction : AuditableEntity, IHasDomainEvent
    {
        public Guid Id { get; set; }
        public Account Account { get; private set; }
        public Position Position { get; private set; }
        public TransactionType TransactionType { get; private set; }
        public double Commission { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public DateTime TransactionDate { get; set; }


        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();

        protected Transaction()
        {
        }

        public Transaction(Account account, Position position, TransactionType transactionType, int quantity, double price, DateTime transactionDate, double commission = 4.95)
        {
            Id = Guid.NewGuid();
            Account = account;
            Position = position;
            TransactionType = transactionType;
            Quantity = quantity >= 0 
                ? quantity
                : throw new PositionTransactionException("Transaction quantity cannot be negative");
            Price = price >= 0 
                ? price
                : throw new PositionTransactionException("Transaction price cannot be negative");
            TransactionDate = transactionDate;
            Commission = commission;

            CalculateNetPrice();
        }

        private void CalculateNetPrice()
        {
            if (TransactionType.Equals(TransactionType.Buy))
            {
                DomainEvents.Add(new PositionPurchasedEvent(this));
            }

            if (TransactionType.Equals(TransactionType.Sell))
            {
                if (Position.Quantity < Quantity)
                {
                    throw new PositionTransactionException($"cannot sell {Quantity} shares of {Position.Ticker}. Only {Position.Quantity} available");
                }
                
                DomainEvents.Add(new PositionSoldEvent(this));
            }

            if (TransactionType.Equals(TransactionType.Dividend))
            {
                Quantity = 0;
                Commission = 0;
                Price = Price;

                DomainEvents.Add(new DividentIssuedEvent(this));
            }
        }
    }
}