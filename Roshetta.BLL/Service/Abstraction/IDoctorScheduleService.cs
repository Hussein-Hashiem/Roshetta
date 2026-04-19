using Roshetta.BLL.Contract.DoctorSchedule;

namespace Roshetta.BLL.Service.Abstraction
{
    public interface IDoctorScheduleService
    {
        Task<Result<List<DoctorScheduleDto>>> GetDoctorSchedulesAsync(string doctorId, CancellationToken cancellationToken = default);
    }
}
