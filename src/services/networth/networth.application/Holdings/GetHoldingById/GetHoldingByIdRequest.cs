using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NetworthApplication.Common.Interfaces;

namespace NetworthApplication.Holdings.GetHoldingById
{
    public class GetHoldingByIdRequest : IRequest<HoldingVm>
    {
        public Guid Id { get; set; }
    }

    public class GetHoldingByIdRequestHandler : IRequestHandler<GetHoldingByIdRequest, HoldingVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHoldingsService _holdingsService;
        private readonly IIdentityService _identityService;

        public GetHoldingByIdRequestHandler(IApplicationDbContext context, IMapper mapper, IHoldingsService holdingsService, IIdentityService identityService)
        {
            _context = context;
            _mapper = mapper;
            _holdingsService = holdingsService;
            _identityService = identityService;
        }

        public async Task<HoldingVm> Handle(GetHoldingByIdRequest request, CancellationToken cancellationToken)
        {
            var holding = await _context.Holdings
                .AsNoTracking()
                .FirstOrDefaultAsync(h => h.Id == request.Id && h.UserId == _identityService.UserId, cancellationToken: cancellationToken);

            holding.HoldingDetails = await _holdingsService.GetDetailsByTickerAsync(holding.Ticker);
            return _mapper.Map<HoldingVm>(holding);
        }
    }
}
