using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("{doctorId}")]
        public async Task<IActionResult> GetDoctorSchedules([FromRoute] string doctorId, CancellationToken cancellationToken)
        {
            var result = await _doctorScheduleService.GetDoctorSchedulesAsync(doctorId, cancellationToken);

            return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
        }
    }
}
