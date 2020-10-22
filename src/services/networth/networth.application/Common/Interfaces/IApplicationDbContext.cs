using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetworthDomain.Entities;

namespace NetworthApplication.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<TodoList> TodoLists { get; set; }

        DbSet<TodoItem> TodoItems { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
