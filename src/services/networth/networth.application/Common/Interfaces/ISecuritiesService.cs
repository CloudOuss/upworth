using System.Threading.Tasks;
using NetworthDomain.Entities;

namespace NetworthApplication.Common.Interfaces
{
    public interface ISecuritiesService
    {
        Task<Security> GetSecurityDetailsAsync(string tickerSymbol);
    }
}
