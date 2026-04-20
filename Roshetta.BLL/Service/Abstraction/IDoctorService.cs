namespace Roshetta.BLL.Service.Abstraction
{
    public interface IDoctorService
    {
        Task<Result<DoctorProfileResponseDto>> GetProfileAsync(string userId, CancellationToken cancellationToken = default);
    }
}
