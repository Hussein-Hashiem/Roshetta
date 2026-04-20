namespace Roshetta.BLL.Service.Abstraction
{
    public interface IDoctorService
    {
        Task<Result<DoctorProfileResponseDto>> GetProfileAsync(string userId, CancellationToken cancellationToken = default);
        Task<Result> UpdateProfileAsync(string userId, UpdateDoctorProfileDto request, CancellationToken cancellationToken = default);
    }
}
