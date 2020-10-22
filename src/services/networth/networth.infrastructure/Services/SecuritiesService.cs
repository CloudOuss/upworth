using System.Threading.Tasks;
using NetworthApplication.Common.Interfaces;
using NetworthDomain.Entities;
using NetworthDomain.Enums;

namespace NetworthInfrastructure.Services
{
    public class SecuritiesService : ISecuritiesService
    {
        public async Task<Security> GetSecurityDetailsAsync(string tickerSymbol)
        {
            //todo: use a concrete implementation of the service
            return new Security(tickerSymbol, Industry.Financials.Value);
        }
    }
}
