namespace Roshetta.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("")]
        public async Task<IActionResult> Login(LoginRequestDto request, CancellationToken cancellationToken)
        {
            var authResult = await _authService.GetTokenAsync(request.Email, request.Password, cancellationToken);

            return authResult!.IsSuccess ? Ok(authResult.Value) : authResult.ToProblem();
        }

        [HttpPost("doctor-registration")]
        public async Task<IActionResult> DoctorRegistration(RegisterRequestDto request, CancellationToken cancellationToken)
        {
            var result = await _authService.RegisterDoctorAsync(request, cancellationToken);

            return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
        }

        [HttpPost("patient-registration")]
        public async Task<IActionResult> PatientRegistration(RegisterRequestDto request, CancellationToken cancellationToken)
        {
            var result = await _authService.RegisterPatientAsync(request, cancellationToken);

            return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
        }

    }
}
