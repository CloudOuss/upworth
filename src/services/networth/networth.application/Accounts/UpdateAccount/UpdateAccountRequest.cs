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
        public int Type { get; set; }
        public int Institution { get; set; }

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

            entity.Name = request.Name;
            entity.SetAccountType(AbstractEnumeration.FromValue<AccountType>(request.Type));
            entity.SetInstitution(AbstractEnumeration.FromValue<Institution>(request.Institution));

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
