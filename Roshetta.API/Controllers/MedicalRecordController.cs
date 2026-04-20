using Microsoft.AspNetCore.Mvc;


namespace Roshetta.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicalRecordController : Controller
    {
        private readonly IMedicalRecordService _medicalRecordService;

        public MedicalRecordController(IMedicalRecordService medicalrecordserivce)
        {
            _medicalRecordService = medicalrecordserivce;
        }
        [HttpPost("{visitId}")]
        public async Task<IActionResult> AddAsync([FromRoute] int visitId, [FromBody] MedicalRecordRequestDto request, CancellationToken cancellation)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = await _medicalRecordService.AddAsync(visitId, userId!, request!, cancellation);

            return result.IsSuccess ? Ok() : result.ToProblem();
        }
        [HttpPut("Visits/{VisitId}/{MedicalRecordId}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int VisitId, [FromRoute] int MedicalRecordId, [FromBody] MedicalRecordRequestDto request, CancellationToken cancellationToken)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = await _medicalRecordService.UpdateAsync(userId!, MedicalRecordId, request!, cancellationToken);

            return result.IsSuccess ? Ok() : result.ToProblem();
        }
        [HttpGet("Patient/{PatientId}/{MedicalRecordId}")]
        // Role
        public async Task<IActionResult> GetMedicalRecordsPerPatient([FromRoute] int MedicalRecordId, [FromRoute] string PatientId, CancellationToken cancellationToken)
        {
            var result = await _medicalRecordService.GetMedicalRecordsPerPatientAsync(PatientId , cancellationToken);

            return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
        }
        //[HttpGet("Visits/{visitId}/Patient/{PatientId}")]
        //public async Task<IActionResult> GetMedicalRecordsById(int VisitId, [FromRoute] string PatientId, CancellationToken cancellationToken)
        //{
        //    var result = await _medicalRecordService.GetMedicalRecordByIdAsync(PatientId, cancellationToken);

        //    return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
        //}
    }
}
