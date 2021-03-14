using System.Threading.Tasks;
using NetworthDomain.ValueObjects;

namespace NetworthApplication.Common.Interfaces
{
    public interface IHoldingsService
    {
        Task<HoldingDetails> GetDetailsByTickerAsync(string tickerSymbol);
    }
}
