using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NetworthApplication.Common.Interfaces;
using NetworthDomain.Entities;
using NetworthDomain.Enums;

namespace NetworthApplication.Accounts.CreateAccount
{
    public record CreateAccountRequest(string Name, int Institution, int Type) : IRequest<Guid>;

    public class CreateAccountRequestHandler : IRequestHandler<CreateAccountRequest, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateAccountRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateAccountRequest request, CancellationToken cancellationToken)
        {
            var entity = new Account(request.Name, 
                AbstractEnumeration.FromValue<Institution>(request.Institution),
                AbstractEnumeration.FromValue<AccountType>(request.Type));

            _context.Accounts.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
