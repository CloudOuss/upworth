using System.Threading.Tasks;
using NetworthDomain.Entities;

namespace NetworthInfrastructure.Dependencies.XpathProvider
{
    public interface IXpathProvider
    {
        Task<Security> GetSecurityDetailsAsync(string ticker);
    }
}