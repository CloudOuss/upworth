using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NetworthApplication.Common.Exceptions;
using NetworthApplication.Common.Interfaces;
using NetworthDomain.Entities;
using NetworthDomain.Enums;

namespace NetworthApplication.Accounts.UpdateAccount
{
    public class UpdateAccountRequest : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

    }

    public class UpdateAccountRequestHandler : IRequestHandler<UpdateAccountRequest>
    {
        private readonly IApplicationDbContext _context;

        public UpdateAccountRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateAccountRequest request, CancellationToken cancellationToken)
        {
            var entity = await _context.Accounts.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Account), request.Id);
            }

            entity.AccountType = AbstractEnumeration.FromName<AccountType>(request.Type);
            entity.Name = request.Name;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
