using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using NetworthApplication.Common.Models;
using NetworthDomain.Events;

namespace NetworthApplication.EventHandlers
{

    public class HoldingPurchasedEventHandler : INotificationHandler<DomainEventNotification<HoldingPurchasedEvent>>
    {
        private readonly ILogger<HoldingPurchasedEventHandler> _logger;

        public HoldingPurchasedEventHandler(ILogger<HoldingPurchasedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(DomainEventNotification<HoldingPurchasedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("NetworthApplication Domain Event: {DomainEvent} with ticker {Ticker}", domainEvent.GetType().Name, domainEvent.Holding.Ticker);

            return Task.CompletedTask;
        }
    }
}
