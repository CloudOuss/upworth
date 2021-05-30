using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NetworthApplication.Common.Exceptions;
using NetworthApplication.Common.Interfaces;
using NetworthDomain.Entities;

namespace NetworthApplication.Accounts.DeleteAccount
{
    public record DeleteAccountRequest(Guid Id) : IRequest;

    public class DeleteAccountRequestHandler : IRequestHandler<DeleteAccountRequest>
    {
        private readonly IApplicationDbContext _context;

        public DeleteAccountRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteAccountRequest request, CancellationToken cancellationToken)
        {
            var entity = await _context.Accounts.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Account), request.Id);
            }

            _context.Accounts.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
