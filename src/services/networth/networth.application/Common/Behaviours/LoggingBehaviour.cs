using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using NetworthApplication.Common.Interfaces;

namespace NetworthApplication.Common.Behaviours
{
    public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _logger;
        private readonly IIdentityService _identityService;

        public LoggingBehaviour(ILogger<TRequest> logger, IIdentityService identityService)
        {
            _logger = logger;
            _identityService = identityService;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            var userId = _identityService.UserId;
            var userName = _identityService.UserName ?? string.Empty;

            await Task.Run(()=>_logger.LogError("NetworthApplication Request: {Name} {@UserId} {@UserName} {@Request}",
                requestName, userId, userName, request), cancellationToken);
        }
    }
}
