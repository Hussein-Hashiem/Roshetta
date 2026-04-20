using Roshetta.BLL.Contract.Doctor;

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
    }
}