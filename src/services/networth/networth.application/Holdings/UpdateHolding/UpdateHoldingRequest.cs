using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NetworthApplication.Common.Exceptions;
using NetworthApplication.Common.Interfaces;
using NetworthDomain.Entities;
using NetworthDomain.Enums;

namespace NetworthApplication.Holdings.UpdateHolding
{
    public class UpdateHoldingRequest : IRequest
    {
        public Guid Id { get; set; }
        public string Ticker { get; set; }
        public double PurchasePrice { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public int Shares { get; set; }
        public Guid AccountId { get; set; }
        public string Currency { get; set; }

    }

    public class UpdateHoldingRequestHandler : IRequestHandler<UpdateHoldingRequest>
    {
        private readonly IApplicationDbContext _context;

        public UpdateHoldingRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateHoldingRequest request, CancellationToken cancellationToken)
        {
            var entity = await _context.Holdings.FindAsync(request.Id);
            var account = await _context.Accounts
                .AsNoTracking()
                .FirstAsync(x => x.Id == request.AccountId, cancellationToken: cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Holding), request.Id);
            }

            entity.Ticker = request.Ticker;
            entity.PurchasePrice = request.PurchasePrice;
            entity.Shares = request.Shares;
            entity.Account = account ?? throw new NotFoundException(nameof(Account), request.AccountId);
            entity.SetCurrency(AbstractEnumeration.FromName<Currency>(request.Currency));

            if (request.PurchaseDate != null)
            {
                entity.Created = (DateTime) request.PurchaseDate;
            }

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
