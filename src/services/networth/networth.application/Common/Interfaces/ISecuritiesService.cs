using System.Threading.Tasks;
using NetworthDomain.Entities;
using NetworthDomain.ValueObjects;

namespace NetworthApplication.Common.Interfaces
{
    public interface ISecuritiesService
    {
        Task<HoldingDetails> GetSecurityDetailsAsync(string tickerSymbol);
    }
}
