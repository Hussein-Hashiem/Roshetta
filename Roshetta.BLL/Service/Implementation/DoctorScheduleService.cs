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

        public async Task<Result> UpdateSchedulesAsync(string doctorId, List<UpdateDoctorScheduleDto> request, CancellationToken cancellationToken = default)
        {
            var doctor = await _doctorRepo.GetDoctorByUserId(doctorId)
                .FirstOrDefaultAsync(cancellationToken);

            if (doctor is null)
                return Result.Failure(UserErrors.NotFouond);

            foreach (var item in request)
            {
                var schedule = new DoctorSchedule
                {
                    Id = item.ScheduleId,
                    StartTime = item.StartTime,
                    EndTime = item.EndTime,
                    MaxVisit = item.MaxVisits,
                    AverageConsultationTime = item.AverageConsultationTime,
                    IsVacation = item.IsVacation
                };

                await _doctorScheduleRepo.UpdateAsync(schedule, doctor.Id, cancellationToken);
            }

            return Result.Success();
        }

    }
}
