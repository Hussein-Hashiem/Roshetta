namespace Roshetta.BLL.Service.Implementation
{
    public class VisitService : IVisitService
    {
        public Task<Result> AddVisitAsync(string userId, int doctorId, AddVisitRequestDto request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Result> DeleteAsync(string userId, int visitId, bool isAdmin, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Result> UpdateVisitAsync(string userId, int visitId, UpdateVisitRequestDto request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}