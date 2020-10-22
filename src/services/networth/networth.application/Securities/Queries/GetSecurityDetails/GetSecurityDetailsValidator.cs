using FluentValidation;
using NetworthApplication.Common.Validation;

namespace NetworthApplication.Securities.Queries.GetSecurityDetails
{
    public class GetSecurityDetailsValidator : AbstractValidator<GetSecurityDetailsQuery>
    {
        public GetSecurityDetailsValidator()
        {
            RuleFor(x => x.Ticker)
                .NotEmpty()
                    .WithMessage(CommonValidation.NotEmptyErrorMessage);
        }
    }
}
