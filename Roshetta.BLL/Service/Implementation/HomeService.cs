using Roshetta.BLL.Contract.Profile;

namespace Roshetta.BLL.Service.Implementation
{
    public class HomeService : IHomeService
    {
        private readonly IPatientRepo _patientRepo;

        public HomeService(IPatientRepo patientRepo)
        {
            _patientRepo = patientRepo;
        }

    }
}