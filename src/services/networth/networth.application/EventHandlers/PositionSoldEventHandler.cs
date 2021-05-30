using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using NetworthApplication.Common.Models;
using NetworthDomain.Events;

namespace NetworthApplication.EventHandlers
{

    public class PositionSoldEventHandler : INotificationHandler<DomainEventNotification<PositionSoldEvent>>
    {
        private readonly ILogger<PositionSoldEventHandler> _logger;

        public PositionSoldEventHandler(ILogger<PositionSoldEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(DomainEventNotification<PositionSoldEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("** Domain Event: {DomainEvent} with ticker {Ticker}", domainEvent.GetType().Name, domainEvent.Transaction.Position.Ticker);

            return Task.CompletedTask;
        }
    }
}