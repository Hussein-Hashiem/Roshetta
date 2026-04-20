
using Roshetta.BLL.Contract.Patient;

namespace Roshetta.BLL.Service.Implementation
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepo _doctorRepo;
        private readonly IVisitRepo _visitRepo;

        public DoctorService(IDoctorRepo doctorRepo, IVisitRepo visitRepo)
        {
            _doctorRepo = doctorRepo;
            _visitRepo = visitRepo;
        }
        public async Task<Result<IEnumerable<DoctorResponseDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var doctors = await _doctorRepo.GetAll()
                .Select(f => new DoctorResponseDto(
                    f.UserId,
                    f.User.Name,
                    f.Department,
                    f.Location,
                    f.Price,
                    f.Inof,
                    f.User.PhoneNumber!
                )).ToListAsync();
            return Result.Success<IEnumerable<DoctorResponseDto>>(doctors);
        }

        public async Task<Result<IEnumerable<PatientDataResponseDto>>> GetPatientsData(string userId, CancellationToken cancellationToken = default)
        {
            var doctor = await _doctorRepo.GetDoctorByUserId(userId).FirstOrDefaultAsync(cancellationToken);
            if (doctor == null) return Result.Failure<IEnumerable<PatientDataResponseDto>>(DoctorErrors.NotFound);
            var patients = await _visitRepo.GetVisitsByDoctorId(doctor.Id)
                .Where(v => v.DoctorId == doctor.Id)
                .Select(f => new PatientDataResponseDto(
                    f.Patient.User.Name,
                    f.Patient.User.DateOfBirth,
                    f.Patient.User.Gender,
                    f.Date,
                    f.Patient.User.PhoneNumber!,
                    f.Patient.User.Email!
                )).ToListAsync(cancellationToken);
            return Result.Success<IEnumerable<PatientDataResponseDto>>(patients);
        }

        public async Task<Result<DoctorProfileResponseDto>> GetProfileAsync(string userId, CancellationToken cancellationToken = default)
        {
            var doctor = await _doctorRepo.GetDoctorByUserId(userId, cancellationToken)
                .Select(x => new DoctorProfileResponseDto(
                    x.User.Id,
                    x.User.Name,
                    x.Inof,
                    x.Department,
                    x.Location,
                    x.User.PhoneNumber!,
                    x.Price,
                    x.User.DateOfBirth
                ))
                .FirstOrDefaultAsync(cancellationToken);

            if (doctor is null)
                return Result.Failure<DoctorProfileResponseDto>(UserErrors.NotFouond);


            return Result.Success(doctor);
        }


    }
}
