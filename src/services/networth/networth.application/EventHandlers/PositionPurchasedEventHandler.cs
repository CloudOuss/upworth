using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using NetworthApplication.Common.Models;
using NetworthDomain.Events;

namespace NetworthApplication.EventHandlers
{

    public class PositionPurchasedEventHandler : INotificationHandler<DomainEventNotification<HoldingPurchasedEvent>>
    {
        private readonly ILogger<PositionPurchasedEventHandler> _logger;

        public PositionPurchasedEventHandler(ILogger<PositionPurchasedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(DomainEventNotification<HoldingPurchasedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("** Domain Event: {DomainEvent} with ticker {Ticker}", domainEvent.GetType().Name, domainEvent.Holding.Ticker);

            return Task.CompletedTask;
        }
    }
}
