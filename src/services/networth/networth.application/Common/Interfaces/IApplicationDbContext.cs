using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetworthDomain.Entities;

namespace NetworthApplication.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Holding> Holdings { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}