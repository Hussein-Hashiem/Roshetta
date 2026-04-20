using Roshetta.BLL.Contract.Doctor;

namespace Roshetta.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;
        public ProfileController(IPatientService patientService, IDoctorService doctorService)
        {
            _patientService = patientService;
            _doctorService = doctorService;
        }

        [HttpGet("patient")]
        public async Task<IActionResult> GetPatientProfile(CancellationToken cancellation)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = await _patientService.GetProfileAsync(userId!, cancellation);

            return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
        }

        [HttpGet("doctor")]
        [Authorize(Roles = DefaultRoles.Doctor)]
        public async Task<IActionResult> GetDoctorProfile(CancellationToken cancellation)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = await _doctorService.GetProfileAsync(userId!, cancellation);

            return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
        }

        [HttpPut("doctor")]
        public async Task<IActionResult> UpdateDoctorProfile([FromBody] UpdateDoctorProfileDto request, CancellationToken cancellationToken = default)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            var result = await _doctorService.UpdateProfileAsync(userId!, request, cancellationToken);
            
            return result.IsSuccess ? NoContent() : result.ToProblem(); 
        }
    }
}