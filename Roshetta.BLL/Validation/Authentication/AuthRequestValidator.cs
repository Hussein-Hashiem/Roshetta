namespace Roshetta.BLL.Validation.Authentication
{
    public class AuthRequestValidator : AbstractValidator<LoginRequestDto>
    {
        public AuthRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
                .MinimumLength(8);
        }
    }
}
