using Roshetta.BLL.Contract.Doctor;
using Roshetta.BLL.Contract.Patient;

namespace Roshetta.BLL.Service.Abstraction
{
    public interface IDoctorService
    {
        Task<Result<IEnumerable<DoctorResponseDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<Result<IEnumerable<PatientDataResponseDto>>> GetPatientsData(string userId, CancellationToken cancellationToken = default);
        Task<Result<DoctorProfileResponseDto>> GetProfileAsync(string userId, CancellationToken cancellationToken = default);
        Task<Result> UpdateProfileAsync(string userId, UpdateDoctorProfileDto request, CancellationToken cancellationToken = default);
    }
}
