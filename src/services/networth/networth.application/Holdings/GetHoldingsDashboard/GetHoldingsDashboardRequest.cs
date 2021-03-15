using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NetworthApplication.Common.Interfaces;

namespace NetworthApplication.Holdings.GetHoldingsDashboard
{
    public class GetHoldingsDashboardRequest : IRequest<IEnumerable<HoldingVm>>
    {
        public Guid Id { get; set; }
    }

    public class GetHoldingsDashboardRequestHandler : IRequestHandler<GetHoldingsDashboardRequest, IEnumerable<HoldingVm>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHoldingsService _holdingsService;
        private readonly IIdentityService _identityService;

        public GetHoldingsDashboardRequestHandler(IApplicationDbContext context, IMapper mapper, IHoldingsService holdingsService, IIdentityService identityService)
        {
            _context = context;
            _mapper = mapper;
            _holdingsService = holdingsService;
            _identityService = identityService;
        }

        public async Task<IEnumerable<HoldingVm>> Handle(GetHoldingsDashboardRequest request, CancellationToken cancellationToken)
        {
            //var holding = await _context.Holdings
            //    .AsNoTracking()
            //    .FirstOrDefaultAsync(h => h.Id == request.Id && h.UserId == _identityService.UserId, cancellationToken: cancellationToken);

            //if(holding != null){
            //    holding.HoldingDetails = await _holdingsService.GetDetailsByTickerAsync(holding.Ticker);
            //}
            
            //return _mapper.Map<HoldingVm>(holding);
            return new List<HoldingVm>();
        }
    }
}
