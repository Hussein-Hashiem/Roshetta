namespace Roshetta.BLL.Service.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtProvider _jwtProvider;

        public AuthService(UserManager<ApplicationUser> userManager, IJwtProvider jwtProvider)
        {
            _userManager = userManager;
            _jwtProvider = jwtProvider;
        }

        public async Task<Result<AuthResponseDto>?> GetTokenAsync(string email, string password, CancellationToken cancellationToken = default)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user is null)
                return Result.Failure<AuthResponseDto>(UserErrors.InvalidCredentials);

            //if (!user.EmailConfirmed)
            //    return Result.Failure<AuthResponseDto>(UserErrors.EmailNotConfirmed);


            var isValidPassword = await _userManager.CheckPasswordAsync(user, password);
            if (!isValidPassword)
                return Result.Failure<AuthResponseDto>(UserErrors.InvalidCredentials);

            // Generate JWT 
            var (token, expiresIn) = _jwtProvider.GenerateToken(user);

            // If all Success 
            return Result.Success(new AuthResponseDto(user.Id, user.Email, user.Name, token, expiresIn));
        }
    }
}
