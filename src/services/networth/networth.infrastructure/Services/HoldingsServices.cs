using System.Threading.Tasks;
using NetworthApplication.Common.Interfaces;
using NetworthDomain.ValueObjects;
using NetworthInfrastructure.Dependencies.XpathProvider;

namespace NetworthInfrastructure.Services
{
    public class HoldingsService : IHoldingsService
    {
        private readonly IXpathProvider _xpathProvider;

        public HoldingsService(IXpathProvider xpathProvider)
        {
            _xpathProvider = xpathProvider;
        }

        public async Task<HoldingDetails> GetDetailsByTickerAsync(string tickerSymbol)
        {
            return await _xpathProvider.GetSecurityDetailsAsync(tickerSymbol);
        }
    }
}
