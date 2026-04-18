
namespace Roshetta.BLL.Service.Abstraction
{
    public interface IAuthService
    {
        Task<Result<AuthResponseDto>?> GetTokenAsync(string email, string password, CancellationToken cancellationToken = default);
        Task<Result<AuthResponseDto>> RegisterDoctorAsync(RegisterRequestDto request, CancellationToken cancellationToken = default);
        Task<Result<AuthResponseDto>> RegisterPatientAsync(RegisterRequestDto request, CancellationToken cancellationToken = default);
    }
}
