namespace Roshetta.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public HomeController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetDoctors(CancellationToken cancellation)
        {
            var result = await _doctorService.GetAll(cancellation);

            return result.IsSuccess ? Ok(result.Value) : result.ToProblem();

        }
    }
}