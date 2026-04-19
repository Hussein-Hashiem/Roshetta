namespace Roshetta.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DoctorScheduleController : ControllerBase
    {
        private readonly IDoctorScheduleService _doctorScheduleService;

        public DoctorScheduleController(IDoctorScheduleService doctorScheduleService)
        {
            _doctorScheduleService = doctorScheduleService;
        }

        [HttpGet("")]
        [Authorize(Roles = DefaultRoles.Doctor)]
        public async Task<IActionResult> GetDoctorSchedules(CancellationToken cancellationToken)
        {
            var doctorId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = await _doctorScheduleService.GetDoctorSchedulesAsync(doctorId!, cancellationToken);

            return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
        }

        [HttpPut("")]
        [Authorize(Roles = DefaultRoles.Doctor)]
        public async Task<IActionResult> UpdateSchedules([FromBody] List<UpdateDoctorScheduleDto> request, CancellationToken cancellationToken = default)
        {
            var doctorId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            var result = await _doctorScheduleService.UpdateSchedulesAsync(doctorId!, request, cancellationToken);

            return result.IsSuccess ? NoContent() : result.ToProblem();  
        }
    }
}
