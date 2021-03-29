using FluentValidation;
using Microsoft.EntityFrameworkCore;
using NetworthApplication.Common.Interfaces;

namespace NetworthApplication.Holdings.UpdateHolding
{
    public class UpdateHoldingValidator : AbstractValidator<UpdateHoldingRequest>
    {
        public UpdateHoldingValidator(IApplicationDbContext context)
        {
            RuleFor(v => v.Shares)
                .GreaterThan(0)
                .NotEmpty();

            RuleFor(x => x.AccountId).MustAsync(async (id, cancellation) => {
                var account = await context.Accounts
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x=>x.Id == id);
                return account != null;
            }).WithMessage("Account must exist");
        }
    }
}
