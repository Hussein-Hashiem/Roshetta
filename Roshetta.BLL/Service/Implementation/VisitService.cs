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

            var isExist = await _visitRepo.IsExist(doctor.Id, patient.Id, request.Date);
            if (isExist) return Result.Failure(VisitErrors.AlreadyBooked);

            var isVacation = await _doctorScheduleRepo.IsVacation(doctor.Id, weekDay);
            if (isVacation) return Result.Failure(VisitErrors.IsVacation);

            var maxVisit = await _doctorScheduleRepo.GetMaxVisit(doctor.Id, weekDay);
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

            if (await _userManager.IsInRoleAsync(user, DefaultRoles.Doctor))
            {
                var doctor = _doctorRepo.GetDoctorByUserId(userId).FirstOrDefault();
                if (doctor == null) return Result.Failure(DoctorErrors.NotFound);
                if (visit.DoctorId != doctor.Id) return Result.Failure(VisitErrors.Unauthorized);
            }
            else if (await _userManager.IsInRoleAsync(user, DefaultRoles.Patient))
            {
                var patient = _patientRepo.GetPatientByUserId(userId).FirstOrDefault();
                if (patient == null) return Result.Failure(PatientErrors.NotFound);
                if (visit.PatientId != patient.Id) return Result.Failure(VisitErrors.Unauthorized);
            }
            visit.IsDeleted = true;

            await _visitRepo.UpdateAsync(visit, cancellationToken);

            return Result.Success();
        }

        public async Task<Result<IEnumerable<VisitResponseDto>>> GetAllAsync(string userId, CancellationToken cancellation = default)
        {
            var doctor = await _doctorRepo.GetDoctorByUserId(userId).FirstOrDefaultAsync();
            var visits = await _visitRepo.GetAll(doctor.Id)
                .Select(f => new VisitResponseDto(
                    f.Id,
                    f.Date,
                    f.Patient.User.Name,
                    f.Patient.User.PhoneNumber!,
                    f.Status
                )).ToListAsync(cancellation);
            return Result.Success<IEnumerable<VisitResponseDto>>(visits);
        }

        public async Task<Result<IEnumerable<VisitResponseDto>>> GetAllPerDayAsync(string userId, CancellationToken cancellation = default)
        {
            var doctor = await _doctorRepo.GetDoctorByUserId(userId).FirstOrDefaultAsync();
            var visits = await _visitRepo.GetAllPerDay(doctor.Id)
                .Select(f => new VisitResponseDto(
                    f.Id,
                    f.Date,
                    f.Patient.User.Name,
                    f.Patient.User.PhoneNumber!,
                    f.Status
                )).ToListAsync(cancellation);
            return Result.Success<IEnumerable<VisitResponseDto>>(visits);
        }

        public async Task<Result<VisitResponseDto>> GetByIdAsync(int visitId, CancellationToken cancellation = default)
        {
            var visit = await _visitRepo.GetById(visitId)
                .Select(f => new VisitResponseDto(
                    f.Id,
                    f.Date,
                    f.Patient.User.Name,
                    f.Patient.User.PhoneNumber!,
                    f.Status
                )).FirstOrDefaultAsync();

            if (visit is null)
                return Result.Failure<VisitResponseDto>(VisitErrors.NotFound);

            return Result.Success(visit);

        }

        public async Task<Result<IEnumerable<PatientVisitResponseDto>>> GetPatientVisitsAsync(string userId, CancellationToken cancellation = default)
        {
            var patient = _patientRepo.GetPatientByUserId(userId).FirstOrDefault();
            if (patient == null) return Result.Failure<IEnumerable<PatientVisitResponseDto>>(PatientErrors.NotFound);

            var visits = await _visitRepo.GetPatientVisit(patient.Id)
                .Select(f => new PatientVisitResponseDto(
                    f.Doctor.User.Name,
                    f.Doctor.Department,
                    f.Date,
                    f.Status
                )).ToListAsync(cancellation);
            return Result.Success<IEnumerable<PatientVisitResponseDto>>(visits);
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