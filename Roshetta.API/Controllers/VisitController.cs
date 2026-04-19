namespace Roshetta.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VisitController : ControllerBase
    {
        private readonly IVisitService _visitService;

        public VisitController(IVisitService visitService)
        {
            _visitService = visitService;
        }
        [HttpPost("")]
        public async Task<IActionResult> Add([FromBody] AddVisitRequestDto request, CancellationToken cancellation)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = await _visitService.AddAsync(userId!, request!, cancellation);

            return result.IsSuccess ? Ok() : result.ToProblem();
        }
        [HttpPut("{visitId}")]
        public async Task<IActionResult> Update([FromRoute] int visitId, UpdateVisitRequestDto request, CancellationToken cancellation)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = await _visitService.UpdateAsync(userId!, visitId, request, cancellation);

            return result.IsSuccess ? NoContent() : result.ToProblem();
        }
        [HttpDelete("{visitId}")]
        public async Task<IActionResult> Delete([FromRoute] int visitId, CancellationToken cancellation)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = await _visitService.DeleteAsync(userId!, visitId, cancellation);

            return result.IsSuccess ? NoContent() : result.ToProblem();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id, CancellationToken cancellation)
        {
            var result = await _fieldSlotService.GetByIdAsync(id, cancellation);

            return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
        }
    }
}