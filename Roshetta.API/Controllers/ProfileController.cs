namespace Roshetta.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public ProfileController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetProfile(CancellationToken cancellation)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = await _patientService.GetProfileAsync(userId!, cancellation);

            return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
        }
    }
}