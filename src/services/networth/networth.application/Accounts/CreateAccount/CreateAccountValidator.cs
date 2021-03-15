using FluentValidation;
using NetworthDomain.Enums;

namespace NetworthApplication.Accounts.CreateAccount
{
    public class CreateAccountValidator : AbstractValidator<CreateAccountRequest>
    {
        public CreateAccountValidator()
        {
            RuleFor(v => v.Name)
                .MaximumLength(200)
                .NotEmpty();
        }
    }
}
