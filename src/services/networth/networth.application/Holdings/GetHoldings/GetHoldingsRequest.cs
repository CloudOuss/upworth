using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NetworthApplication.Common.Interfaces;

namespace NetworthApplication.Holdings.GetHoldings


{
    public class GetHoldingsRequest : IRequest<List<HoldingVm>>
    {
    }

    public class GetHoldingsRequestHandler : IRequestHandler<GetHoldingsRequest, List<HoldingVm>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IIdentityService _identityService;        
        private readonly IHoldingsService _holdingsService;
        private readonly ILogger<GetHoldingsRequestHandler> _logger;

        public GetHoldingsRequestHandler(IApplicationDbContext context, IMapper mapper, IIdentityService identityService, ILogger<GetHoldingsRequestHandler> logger, IHoldingsService holdingsService)
        {
            _context = context;
            _mapper = mapper;
            _identityService = identityService;
            _logger = logger;
            _holdingsService = holdingsService;
        }

        public async Task<List<HoldingVm>> Handle(GetHoldingsRequest request, CancellationToken cancellationToken)
        {
            var results= new List<HoldingVm>();

            var holdings =  _context.Holdings
                .Where(x=>x.UserId == _identityService.UserId)
                .OrderByDescending(x => x.Created)
                .ToList();

            foreach (var holding in holdings)
            {
                holding.HoldingDetails = await _holdingsService.GetDetailsByTickerAsync(holding.Ticker);
                results.Add(_mapper.Map<HoldingVm>(holding));
            }
            
            return await Task.Run(() => results.ToList(), cancellationToken);
        }
    }
}