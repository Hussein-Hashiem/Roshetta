
namespace Roshetta.BLL.Service.Abstraction
{
    public interface IAuthService
    {
        Task<Result<AuthResponseDto>?> GetTokenAsync(string email, string password, CancellationToken cancellationToken = default);

    }
}
