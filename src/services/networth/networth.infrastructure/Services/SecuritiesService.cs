using System.Threading.Tasks;
using NetworthApplication.Common.Interfaces;
using NetworthDomain.ValueObjects;
using NetworthInfrastructure.Dependencies.XpathProvider;

namespace NetworthInfrastructure.Services
{
    public class SecuritiesService : ISecuritiesService
    {
        private readonly IXpathProvider _xpathProvider;

        public SecuritiesService(IXpathProvider xpathProvider)
        {
            _xpathProvider = xpathProvider;
        }

        public async Task<HoldingDetails> GetSecurityDetailsAsync(string tickerSymbol)
        {
            return await _xpathProvider.GetSecurityDetailsAsync(tickerSymbol);
        }
    }
}
