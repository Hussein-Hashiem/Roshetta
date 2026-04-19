using Roshetta.BLL.Contract.DoctorSchedule;

namespace Roshetta.BLL.Service.Implementation
{
    public class DoctorScheduleService : IDoctorScheduleService
    {
        private readonly IDoctorRepo _doctorRepo;
        private readonly IDoctorScheduleRepo _doctorScheduleRepo;

        public DoctorScheduleService(IDoctorRepo doctorRepo, IDoctorScheduleRepo doctorScheduleRepo)
        {
            _doctorRepo = doctorRepo;
            _doctorScheduleRepo = doctorScheduleRepo;
        }

        public async Task<Result<List<DoctorScheduleDto>>> GetDoctorSchedulesAsync(string doctorId, CancellationToken cancellationToken = default)
        {
            var doctor = await _doctorRepo.GetDoctorByUserId(doctorId)
                .FirstOrDefaultAsync(cancellationToken);

            if (doctor is null)
                return Result.Failure<List<DoctorScheduleDto>>(UserErrors.NotFouond);

            var result = _doctorScheduleRepo.GetAllSchedulesForDoctor(doctor.Id)
                .Select(x => new DoctorScheduleDto(
                x.Id,
                x.Day.ToString(),
                x.StartTime,
                x.EndTime,
                x.IsVacation,
                x.AverageConsultationTime,
                x.MaxVisit
            )).ToList();

            return Result.Success(result);
        }

    }
}
