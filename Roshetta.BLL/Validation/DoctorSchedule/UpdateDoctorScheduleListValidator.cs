using Roshetta.BLL.Contract.DoctorSchedule;

namespace Roshetta.BLL.Validation.DoctorSchedule
{
    public class UpdateDoctorScheduleListValidator : AbstractValidator<List<UpdateDoctorScheduleDto>>
    {
        public UpdateDoctorScheduleListValidator()
        {
            RuleFor(x => x)
            .NotEmpty();

            RuleForEach(x => x)
                .SetValidator(new UpdateDoctorScheduleValidator());
        }
    }
}
