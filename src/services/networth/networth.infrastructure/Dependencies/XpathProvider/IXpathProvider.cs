using System.Threading.Tasks;
using NetworthDomain.Entities;
using NetworthDomain.ValueObjects;

namespace NetworthInfrastructure.Dependencies.XpathProvider
{
    public interface IXpathProvider
    {
        Task<HoldingDetails> GetSecurityDetailsAsync(string ticker);
    }
}