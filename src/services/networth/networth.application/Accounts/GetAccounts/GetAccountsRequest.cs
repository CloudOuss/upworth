using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NetworthApplication.Common.Interfaces;

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

        public GetAccountsRequestHandler(IApplicationDbContext context, IMapper mapper, IIdentityService identityService)
        {
            _context = context;
            _mapper = mapper;
            _identityService = identityService;
        }

        public async Task<List<AccountVm>> Handle(GetAccountsRequest request, CancellationToken cancellationToken)
        {
            return await _context.Accounts
                .Where(x=>x.UserId == _identityService.UserId)
                .OrderBy(x => x.Name)
                .ProjectTo<AccountVm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}