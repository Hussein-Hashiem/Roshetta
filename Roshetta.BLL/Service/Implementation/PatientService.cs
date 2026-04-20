using Roshetta.BLL.Contract;
using Roshetta.BLL.Contract.Profile;

namespace Roshetta.BLL.Service.Implementation
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepo _patientRepo;
        public PatientService(IPatientRepo patientRepo)
        {
            _patientRepo = patientRepo;
        }

        public async Task<Result> DeleteAsync(string UserId, CancellationToken cancellationToken = default)
        {
            var patient = await _patientRepo.GetPatientByUserId(UserId, cancellationToken).FirstOrDefaultAsync();
            if (patient == null) return Result.Failure(UserErrors.NotFouond);

            await _patientRepo.DeleteAsync(UserId, cancellationToken);

            return Result.Success();
        }

        public async Task<Result<IEnumerable<ProfileResponseDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var patients = await _patientRepo.GetAll()
                .Select(f => new ProfileResponseDto(
                    f.UserId,
                    f.User.Name,
                    f.User.Image,
                    f.User.DateOfBirth,
                    f.User.Gender
                )).ToListAsync();
            return Result.Success<IEnumerable<ProfileResponseDto>>(patients);
        }


        public async Task<Result<ProfileResponseDto>> GetProfileAsync(string userId, CancellationToken cancellationToken)
        {
            var patient = await _patientRepo.GetPatientByUserId(userId).Select(patient => new ProfileResponseDto(
                    patient.UserId,
                    patient.User.Name,
                    patient.User.PhoneNumber!,
                    patient.User.DateOfBirth,
                    patient.User.Gender
                )).FirstOrDefaultAsync();
            if (patient == null) return Result.Failure<ProfileResponseDto>(PatientErrors.NotFound);
            return Result.Success<ProfileResponseDto>(patient!);
        }

        public async Task<Result> UpdateAsync(string userId, UpdatePatientRequestDto request, CancellationToken cancellationToken = default)
        {
            var patient = new Patient()
            {
                User = new ApplicationUser()
                {
                    Name = request.Name,
                    PhoneNumber = request.PhoneNumber,
                    DateOfBirth = request.DateOfBirth,
                    Gender = request.Gender
                }
            };

            await _patientRepo.UpdateAsync(userId, patient, cancellationToken);
            return Result.Success();
        }
    }
}
