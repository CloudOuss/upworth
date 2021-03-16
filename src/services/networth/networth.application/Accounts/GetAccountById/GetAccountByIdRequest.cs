using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NetworthApplication.Common.Interfaces;

namespace NetworthApplication.Accounts.GetAccountById


{
    public class GetAccountByIdRequest : IRequest<AccountVm>
    {
        public Guid Id { get; set; }
    }

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

            return _mapper.Map<AccountVm>(account);
        }
    }
}