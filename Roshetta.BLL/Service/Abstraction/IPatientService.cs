using Roshetta.BLL.Contract.DoctorSchedule;
using Roshetta.BLL.Contract.Patient;
namespace Roshetta.BLL.Service.Abstraction
{
    public interface IPatientService
    {
        Task<Result<List<PatientDto>>> GetAll();
        Task<Result<PatientDto>> GetById(int id);
        Task<Result> AddAsync(string userId, PatientDto request, CancellationToken cancellationToken = default);
        Task<Result> DeleteAync(int id, CancellationToken cancellationToken = default);
    }
}
