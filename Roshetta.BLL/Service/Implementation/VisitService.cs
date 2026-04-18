namespace Roshetta.BLL.Service.Implementation
{
    public class VisitService : IVisitService
    {
        private readonly IVisitRepo _visitRepo;
        private readonly IPatientRepo _patientRepo;
        public VisitService(IVisitRepo visitRepo, IPatientRepo patientRepo)
        {
            _visitRepo = visitRepo;
            _patientRepo = patientRepo;
        }

        public Task<Result> AddVisitAsync(string userId, int doctorId, AddVisitRequestDto request, CancellationToken cancellationToken = default)
        {
            var patient = _patientRepo.GetPatientByUserId(userId).FirstOrDefault();
            var dayName = request.Date.DayOfWeek.ToString();
        }

        public Task<Result> UpdateVisitAsync(string userId, int visitId, UpdateVisitRequestDto request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}