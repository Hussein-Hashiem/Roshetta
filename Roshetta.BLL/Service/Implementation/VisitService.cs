namespace Roshetta.BLL.Service.Implementation
{
    public class VisitService : IVisitService
    {
        private readonly IVisitRepo _visitRepo;
        private readonly IPatientRepo _patientRepo;
        private readonly IDoctorRepo _doctorRepo;
        private readonly IDoctorScheduleRepo _doctorScheduleRepo;
        private readonly UserManager<ApplicationUser> _userManager;
        public VisitService(IVisitRepo visitRepo, IPatientRepo patientRepo, IDoctorScheduleRepo doctorScheduleRepo, IDoctorRepo doctorRepo, UserManager<ApplicationUser> userManager)
        {
            _visitRepo = visitRepo;
            _patientRepo = patientRepo;
            _doctorScheduleRepo = doctorScheduleRepo;
            _doctorRepo = doctorRepo;
            _userManager = userManager;
        }

        public async Task<Result> AddAsync(string userId, AddVisitRequestDto request, CancellationToken cancellationToken = default)
        {
            var patient = _patientRepo.GetPatientByUserId(userId).FirstOrDefault();
            if (patient == null) return Result.Failure(PatientErrors.NotFound);

            var doctor = _doctorRepo.GetDoctorByUserId(request.DoctorId).FirstOrDefault();
            if (doctor == null) return Result.Failure(DoctorErrors.NotFound);

            var weekDay = Enum.Parse<WeekDay>(request.Date.DayOfWeek.ToString());
            var maxVisit = await _doctorScheduleRepo.GetMaxVisit(doctor.Id, weekDay);
            var bookedPatients = await _visitRepo.GetPatientCountOnDay(doctor.Id, request.Date);

            // ======= ya walliy elne3m ==========
            // Console.WriteLine($"maxVisit {maxVisit}");
            // Console.WriteLine($"booked {bookedPatients}");

            if (bookedPatients >= maxVisit)
                return Result.Failure(VisitErrors.DayFull);

            var visit = new Visit
            {
                Status = Status.Pending,
                Date = request.Date,
                PatientId = patient.Id,
                DoctorId = doctor.Id
            };

            await _visitRepo.AddAsync(visit, cancellationToken);

            return Result.Success();
        }

        public async Task<Result> DeleteAsync(string userId, int visitId, CancellationToken cancellationToken = default)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return Result.Failure(UserErrors.NotFouond);

            var visit = _visitRepo.GetById(visitId).FirstOrDefault();
            if (visit == null) return Result.Failure(VisitErrors.NotFound);

            if (visit.IsDeleted) return Result.Failure(VisitErrors.AlreadyDeleted);

            if (await _userManager.IsInRoleAsync(user, "Doctor"))
            {
                var doctor = _doctorRepo.GetDoctorByUserId(userId).FirstOrDefault();
                if (doctor == null) return Result.Failure(DoctorErrors.NotFound);
                if (visit.DoctorId != doctor.Id) return Result.Failure(VisitErrors.Unauthorized);
            }
            else if (await _userManager.IsInRoleAsync(user, "Patient"))
            {
                var patient = _patientRepo.GetPatientByUserId(userId).FirstOrDefault();
                if (patient == null) return Result.Failure(PatientErrors.NotFound);
                if (visit.PatientId != patient.Id) return Result.Failure(VisitErrors.Unauthorized);
            }
            visit.IsDeleted = true;

            await _visitRepo.UpdateAsync(visit, cancellationToken);

            return Result.Success();
        }

        public async Task<Result> UpdateAsync(string userId, int visitId, UpdateVisitRequestDto request, CancellationToken cancellationToken = default)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return Result.Failure(UserErrors.NotFouond);

            var visit = _visitRepo.GetById(visitId).FirstOrDefault();
            if (visit == null) return Result.Failure(VisitErrors.NotFound);

            if (await _userManager.IsInRoleAsync(user, "Doctor"))
            {
                var doctor = _doctorRepo.GetDoctorByUserId(userId).FirstOrDefault();
                if (doctor == null) return Result.Failure(DoctorErrors.NotFound);
                if (visit.DoctorId != doctor.Id) return Result.Failure(VisitErrors.Unauthorized);
            }
            else if (await _userManager.IsInRoleAsync(user, "Patient"))
            {
                var patient = _patientRepo.GetPatientByUserId(userId).FirstOrDefault();
                if (patient == null) return Result.Failure(PatientErrors.NotFound);
                if (visit.PatientId != patient.Id) return Result.Failure(VisitErrors.Unauthorized);
            }

            visit.Status = request.Status;
            await _visitRepo.UpdateAsync(visit, cancellationToken);

            return Result.Success();
        }
    }
}