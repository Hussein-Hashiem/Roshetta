
namespace Roshetta.BLL.Validation.Authentication
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequestDto>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
                .MinimumLength(8);

            RuleFor(x => x.Name)
                .NotEmpty();

            RuleFor(x => x.PhoneNumber)
                .NotEmpty();

            RuleFor(x => x.DateOfBirth)
                .NotEmpty()
                .LessThan(DateOnly.FromDateTime(DateTime.UtcNow));
        }
    }
}
