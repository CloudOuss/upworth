using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NetworthApplication.Common.Interfaces;
using NetworthDomain.Entities;
using NetworthDomain.Enums;

namespace NetworthApplication.Accounts.GetAccounts


{
    public class GetAccountsRequest : IRequest<List<AccountVm>>
    {
    }

    public class GetAccountsRequestHandler : IRequestHandler<GetAccountsRequest, List<AccountVm>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IIdentityService _identityService;
        private readonly ILogger<GetAccountsRequestHandler> _logger;

        public GetAccountsRequestHandler(IApplicationDbContext context, IMapper mapper, IIdentityService identityService, ILogger<GetAccountsRequestHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _identityService = identityService;
            _logger = logger;
        }

        public async Task<List<AccountVm>> Handle(GetAccountsRequest request, CancellationToken cancellationToken)
        {
            var results= new List<AccountVm>();

            var accounts =  _context.Accounts
                .Where(x=>x.UserId == _identityService.UserId)
                .OrderBy(x => x.Name)
                .ToList();

            foreach (Account account in accounts)
            {
                account.SetAccountType(AbstractEnumeration.FromValue<AccountType>(account.AccountTypeId));
                account.SetInstitution(AbstractEnumeration.FromValue<Institution>(account.InstitutionId));
                results.Add(_mapper.Map<AccountVm>(account));
            }
            
            return await Task.Run(() => results.ToList(), cancellationToken);
        }
    }
}