using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NetworthApplication.Common.Interfaces;
using NetworthDomain.Entities;
using NetworthDomain.Enums;
using NetworthDomain.Events;

namespace NetworthApplication.Holdings.CreateHolding
{
    public class CreateHoldingRequest : IRequest<Guid>
    {
        public string Ticker { get; set; }
        public double PurchasePrice { get; set; }
        public int Shares { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public Guid AccountId { get; set; }
        public string Currency { get; set; }
    }

    public class CreateHoldingRequestHandler : IRequestHandler<CreateHoldingRequest, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateHoldingRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateHoldingRequest request, CancellationToken cancellationToken)
        {
            var account = await _context.Accounts
                .FirstOrDefaultAsync(x=>x.Id == request.AccountId, cancellationToken: cancellationToken);
            
            if(account == null){
                throw new Exception();
            }

            var entity = new Holding(request.Ticker, request.PurchasePrice, request.Shares, account,
                request.PurchaseDate, AbstractEnumeration.FromName<Currency>(request.Currency));
            entity.DomainEvents.Add(new HoldingPurchasedEvent(entity));

            _context.Holdings.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
