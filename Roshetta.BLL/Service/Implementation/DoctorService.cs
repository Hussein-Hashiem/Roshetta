namespace Roshetta.BLL.Service.Implementation
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepo _doctorRepo;

        public DoctorService(IDoctorRepo doctorRepo)
        {
            _doctorRepo = doctorRepo;
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
