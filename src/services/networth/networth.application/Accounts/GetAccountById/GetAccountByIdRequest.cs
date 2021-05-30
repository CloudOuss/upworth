using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NetworthApplication.Common.Interfaces;
using NetworthDomain.Enums;

namespace NetworthApplication.Accounts.GetAccountById


{
    public record GetAccountByIdRequest(Guid Id) : IRequest<AccountVm>;

    public class GetAccountByIdRequestHandler : IRequestHandler<GetAccountByIdRequest, AccountVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IIdentityService _identityService;

        public GetAccountByIdRequestHandler(IApplicationDbContext context, IMapper mapper, IIdentityService identityService)
        {
            _context = context;
            _mapper = mapper;
            _identityService = identityService;
        }

        public async Task<AccountVm> Handle(GetAccountByIdRequest byIdRequest, CancellationToken cancellationToken)
        {
            var account = await _context.Accounts
                .AsNoTracking()
                .FirstOrDefaultAsync(h => h.Id == byIdRequest.Id && h.UserId == _identityService.UserId, cancellationToken: cancellationToken);

            account.SetAccountType(AbstractEnumeration.FromValue<AccountType>(account.AccountTypeId));
            account.SetInstitution(AbstractEnumeration.FromValue<Institution>(account.InstitutionId));
            return _mapper.Map<AccountVm>(account);
        }
    }
}