using Roshetta.BLL.Contract.DoctorSchedule;

namespace Roshetta.BLL.Validation.DoctorSchedule
{
    public class UpdateDoctorScheduleValidator : AbstractValidator<UpdateDoctorScheduleDto>
    {
        public UpdateDoctorScheduleValidator()
        {
            RuleFor(x => x.AverageConsultationTime)
            .GreaterThan(0);

            RuleFor(x => x.EndTime)
                .GreaterThan(x => x.StartTime)
                .When(x => !x.IsVacation);

            RuleFor(x => x.MaxVisits)
                .GreaterThan(0);
        }
    }
}
