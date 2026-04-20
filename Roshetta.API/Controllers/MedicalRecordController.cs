using Microsoft.AspNetCore.Mvc;

namespace Roshetta.API.Controllers
{
    public class MedicalRecordController : Controller
    {
        private readonly IMedicalRecordService _medicalRecordService;

        public MedicalRecordController(IMedicalRecordService medicalrecordserivce)
        {
            _medicalRecordService = medicalrecordserivce;
        }
    }
}
