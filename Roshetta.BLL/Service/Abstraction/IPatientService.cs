using Roshetta.BLL.Contract;
using Roshetta.BLL.Contract.DoctorSchedule;
using Roshetta.BLL.Contract.Profile;
namespace Roshetta.BLL.Service.Abstraction
{
    public interface IPatientService
    {
        Task<Result<IEnumerable<ProfileResponseDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<Result<ProfileResponseDto>> GetProfileAsync(string userId, CancellationToken cancellationToken);
        Task<Result> DeleteAsync(string UserId, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(string userId, UpdatePatientRequestDto request, CancellationToken cancellationToken = default);
    }
}
