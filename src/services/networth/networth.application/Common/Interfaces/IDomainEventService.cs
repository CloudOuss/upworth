using System.Threading.Tasks;
using NetworthDomain.Common;

namespace NetworthApplication.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
