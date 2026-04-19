namespace Roshetta.BLL.Service.Implementation
{
    public class VisitService : IVisitService
    {
        private readonly IVisitRepo _visitRepo;
        private readonly IPatientRepo _patientRepo;
        private readonly IDoctorRepo _doctorRepo;
        private readonly IDoctorScheduleRepo _doctorScheduleRepo;
        public VisitService(IVisitRepo visitRepo, IPatientRepo patientRepo, IDoctorScheduleRepo doctorScheduleRepo, IDoctorRepo doctorRepo)
        {
            _visitRepo = visitRepo;
            _patientRepo = patientRepo;
            _doctorScheduleRepo = doctorScheduleRepo;
            _doctorRepo = doctorRepo;
        }

        public async Task<Result> AddVisitAsync(string userId, AddVisitRequestDto request, CancellationToken cancellationToken = default)
        {
            var patient = _patientRepo.GetPatientByUserId(userId).FirstOrDefault();
            var doctor = _doctorRepo.GetDoctorByUserId(userId).FirstOrDefault();
            var dayName = request.Date.DayOfWeek.ToString();
            var maxVisit = await _doctorScheduleRepo.GetMaxVisit(doctor.Id);
            var bookedPatients = await _visitRepo.GetPatientCountOnDay(doctor.Id, request.Date);
            if (bookedPatients >= maxVisit)
                return Result.Failure(VisitErrors.DayFull);
            var visit = new Visit
            {
                Status = Status.Pending,
                Date = request.Date,
                PatientId = patient.Id,
                DoctorId = doctor.Id
            };
            return Result.Success();

        }

        public Task<Result> UpdateVisitAsync(string userId, int visitId, UpdateVisitRequestDto request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}