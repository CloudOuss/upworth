using FluentValidation;

namespace NetworthApplication.Accounts.UpdateAccount
{
    public class UpdateAccountRequestValidator : AbstractValidator<UpdateAccountRequest>
    {
        public UpdateAccountRequestValidator()
        {
            RuleFor(v => v.Name)
                .MaximumLength(200)
                .NotEmpty();
        }
    }
}
