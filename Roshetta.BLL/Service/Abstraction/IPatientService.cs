using Roshetta.BLL.Contract.DoctorSchedule;
using Roshetta.BLL.Contract.Patient;
namespace Roshetta.BLL.Service.Abstraction
{
    public interface IPatientService
    {
        Task<Result<IEnumerable<PatientDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<Result<PatientDto>> GetByIdAsync(string UserId, CancellationToken cancellationToken = default);
        Task<Result> DeleteAsync(string UserId, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(string userId, PatientDto patient, CancellationToken cancellationToken = default);
    }
}
