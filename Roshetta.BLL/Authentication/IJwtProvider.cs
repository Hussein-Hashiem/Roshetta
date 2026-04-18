using Roshetta.DAL.Entities;

namespace Roshetta.BLL.Authentication
{
    public interface IJwtProvider
    {
        (string token, int expiresIn) GenerateToken(ApplicationUser user, IEnumerable<string> roles);
    }
}
