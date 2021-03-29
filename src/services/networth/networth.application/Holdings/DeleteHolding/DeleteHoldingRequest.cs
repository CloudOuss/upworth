using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NetworthApplication.Common.Exceptions;
using NetworthApplication.Common.Interfaces;
using NetworthDomain.Entities;

namespace NetworthApplication.Holdings.DeleteHolding
{
    public class DeleteHoldingRequest : IRequest
    {
        public Guid Id { get; set; }
    }

    public class DeleteHoldingRequestHandler : IRequestHandler<DeleteHoldingRequest>
    {
        private readonly IApplicationDbContext _context;

        public DeleteHoldingRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteHoldingRequest request, CancellationToken cancellationToken)
        {
            var entity = await _context.Holdings.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Holding), request.Id);
            }

            _context.Holdings.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
