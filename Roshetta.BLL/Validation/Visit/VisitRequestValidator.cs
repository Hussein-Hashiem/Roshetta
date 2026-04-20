namespace Roshetta.BLL.Validation.Visit
{
    public class VisitRequestValidator : AbstractValidator<AddVisitRequestDto>
    {
        public VisitRequestValidator()
        {
            RuleFor(x => x.Date)
                .Must(date => date >= DateOnly.FromDateTime(DateTime.Today));
        }
    }
}