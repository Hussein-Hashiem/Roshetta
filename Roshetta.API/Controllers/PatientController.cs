namespace Roshetta.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IVisitService _visitService;

        public PatientController(IVisitService visitService)
        {
            _visitService = visitService;
        }


        [HttpGet("")]
        public async Task<IActionResult> GetMyBooks(CancellationToken cancellation)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = await _visitService.GetPatientVisitsAsync(userId!, cancellation);

            return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
        }
    }
}