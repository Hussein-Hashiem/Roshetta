namespace Roshetta.BLL.Service.Abstraction
{
    public interface IVisitService
    {
        Task<Result> AddVisitAsync(string userId, int doctorId, AddVisitRequestDto request, CancellationToken cancellationToken = default);
        Task<Result> UpdateVisitAsync(string userId, int visitId, UpdateVisitRequestDto request, CancellationToken cancellationToken = default);
        //   Task<Result> DeleteAsync(string userId, int visitId, bool isAdmin, CancellationToken cancellationToken = default);
    }
}