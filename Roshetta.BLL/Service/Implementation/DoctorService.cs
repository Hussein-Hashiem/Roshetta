
namespace Roshetta.BLL.Service.Implementation
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepo _doctorRepo;

        public DoctorService(IDoctorRepo doctorRepo)
        {
            _doctorRepo = doctorRepo;
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
