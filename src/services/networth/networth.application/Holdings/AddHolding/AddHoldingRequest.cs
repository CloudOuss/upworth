using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NetworthApplication.Common.Interfaces;
using NetworthDomain.Entities;

namespace NetworthApplication.Holdings.AddHolding
{
    public class AddHoldingRequest : IRequest<Guid>
    {
        public string Ticker { get; set; }
        public double BuyPrice { get; set; }
        public int ShareNumber { get; set; }
    }

    public class AddHoldingRequestHandler : IRequestHandler<AddHoldingRequest, Guid>
    {
        private readonly IApplicationDbContext _context;

        public AddHoldingRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(AddHoldingRequest request, CancellationToken cancellationToken)
        {
            var entity = new Holding(request.Ticker, request.BuyPrice, request.ShareNumber);
            _context.Holdings.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
