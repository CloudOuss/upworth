using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NetworthApplication.Common.Interfaces;
using NetworthApplication.Holdings;
using NetworthDomain.Enums;

namespace NetworthApplication.Portfolio.GetPortfolio


{
    public class GetPortfolioRequest : IRequest<PortfolioVm>
    {
    }

    public class GetPortfolioRequestHandler : IRequestHandler<GetPortfolioRequest, PortfolioVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IIdentityService _identityService;        
        private readonly IHoldingsService _holdingsService;
        private readonly ILogger<GetPortfolioRequestHandler> _logger;

        public GetPortfolioRequestHandler(IApplicationDbContext context, IMapper mapper, IIdentityService identityService, ILogger<GetPortfolioRequestHandler> logger, IHoldingsService holdingsService)
        {
            _context = context;
            _mapper = mapper;
            _identityService = identityService;
            _logger = logger;
            _holdingsService = holdingsService;
        }

        public async Task<PortfolioVm> Handle(GetPortfolioRequest request, CancellationToken cancellationToken)
        {
            var portfolio = new PortfolioVm();
            var holdingsResult = new List<HoldingVm>();

            var holdings =  _context.Holdings
                .Where(x=>x.UserId == _identityService.UserId)
                .OrderByDescending(x => x.Created)
                .ToList();

            foreach (var holding in holdings)
            {
                holding.SetAccountDetails(await _holdingsService.GetDetailsByTickerAsync(holding.Ticker));
                holding.SetCurrency(AbstractEnumeration.FromValue<Currency>(holding.CurrencyId));
                holdingsResult.Add(_mapper.Map<HoldingVm>(holding));
            }

            portfolio.TotalShares = holdings.Sum(h=>h.Shares);
            portfolio.TotalAverageCost = holdings.Average(h=>h.PurchasePrice);
            portfolio.TotalCostBasis =  holdings.Sum(h=>h.CostBasis);
            portfolio.TotalMarketValue = holdings.Sum(h=>h.MarketValue);
            portfolio.TotalGainLoss = holdings.Sum(h=>h.GainLoss);
            portfolio.TotalGainLossPercent = portfolio.TotalGainLoss / portfolio.TotalCostBasis;
            
            foreach (var holdingResult in holdingsResult)
            {
                holdingResult.Weight = holdingResult.CostBasis / portfolio.TotalMarketValue;
            }

            portfolio.Holdings = holdingsResult;

            return portfolio;
        }
    }
}