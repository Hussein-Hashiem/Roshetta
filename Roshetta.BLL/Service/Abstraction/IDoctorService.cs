using Roshetta.BLL.Contract.Doctor;

namespace Roshetta.BLL.Service.Abstraction
{
    public interface IDoctorService
    {
        Task<Result<IEnumerable<DoctorResponseDto>>> GetAll(CancellationToken cancellationToken = default);

    }
}