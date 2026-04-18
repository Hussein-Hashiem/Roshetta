
using Microsoft.AspNetCore.Http;
using Roshetta.DAL.Abstraction;
using Roshetta.DAL.Repo.Abstraction;

namespace Roshetta.BLL.Service.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPatientRepo _patientRepo;
        private readonly IDoctorRepo _doctorRepo;
        private readonly IJwtProvider _jwtProvider;

        public AuthService(UserManager<ApplicationUser> userManager, IJwtProvider jwtProvider, IPatientRepo patientRepo, IDoctorRepo doctorRepo)
        {
            _userManager = userManager;
            _jwtProvider = jwtProvider;
            _patientRepo = patientRepo;
            _doctorRepo = doctorRepo;
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

            var userRoles = await _userManager.GetRolesAsync(user);

            // Generate JWT 
            var (token, expiresIn) = _jwtProvider.GenerateToken(user, userRoles);

            // If all Success 
            return Result.Success(new AuthResponseDto(user.Id, user.Email, user.Name, token, userRoles.FirstOrDefault()!, user.Gender.ToString(), expiresIn));
        }

        public async Task<Result<AuthResponseDto>> RegisterDoctorAsync(RegisterRequestDto request, CancellationToken cancellationToken = default)
        {
            var emailIsExists = await _userManager.Users.AnyAsync(x => x.Email ==  request.Email, cancellationToken);

            if (emailIsExists)
                return Result.Failure<AuthResponseDto>(UserErrors.DuplicatedEmail);

            var user = new ApplicationUser
            {
                Email = request.Email,
                UserName = request.Email,
                Name = request.Name,
                EmailConfirmed = true,
                PhoneNumber = request.PhoneNumber,
                DateOfBirth = request.DateOfBirth,
                Gender = request.Gender.ToUpper() == "MALE" ? Gender.Male: Gender.Female
            };
            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                var doctor = new Doctor { UserId = user.Id };

                 await _doctorRepo.AddAsync(doctor);

                await _userManager.AddToRoleAsync(user, DefaultRoles.Doctor);

                // Generate JWT 
                var (token, expiresIn) = _jwtProvider.GenerateToken(user, [DefaultRoles.Doctor]);

                return Result.Success(new AuthResponseDto(user.Id, user.Email, user.Name, token, DefaultRoles.Doctor, user.Gender.ToString(), expiresIn));
            }

            var error = result.Errors.First();
            return Result.Failure<AuthResponseDto>(new Error(error.Code, error.Description, ErrorType.BadRequest));
        }

        public async Task<Result<AuthResponseDto>> RegisterPatientAsync(RegisterRequestDto request, CancellationToken cancellationToken = default)
        {
            var emailIsExists = await _userManager.Users.AnyAsync(x => x.Email ==  request.Email, cancellationToken);

            if (emailIsExists)
                return Result.Failure<AuthResponseDto>(UserErrors.DuplicatedEmail);

            var user = new ApplicationUser
            {
                Email = request.Email,
                UserName = request.Email,
                Name = request.Name,
                EmailConfirmed = true,
                PhoneNumber = request.PhoneNumber,
                DateOfBirth = request.DateOfBirth,
                Gender = request.Gender.ToUpper() == "MALE" ? Gender.Male : Gender.Female
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                var patient = new Patient { UserId = user.Id };

                await _patientRepo.AddAsync(patient);

                await _userManager.AddToRoleAsync(user, DefaultRoles.Patient);

                // Generate JWT 
                var (token, expiresIn) = _jwtProvider.GenerateToken(user, [DefaultRoles.Patient]);

                return Result.Success(new AuthResponseDto(user.Id, user.Email, user.Name, token, DefaultRoles.Patient, user.Gender.ToString(), expiresIn));
            }

            var error = result.Errors.First();
            return Result.Failure<AuthResponseDto>(new Error(error.Code, error.Description, ErrorType.BadRequest));
        }
    }
}
