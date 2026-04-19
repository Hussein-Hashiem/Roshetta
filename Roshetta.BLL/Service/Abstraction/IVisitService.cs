namespace Roshetta.BLL.Service.Abstraction
{
    public interface IVisitService
    {
        Task<Result> AddAsync(string userId, AddVisitRequestDto request, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(string userId, int visitId, UpdateVisitRequestDto request, CancellationToken cancellationToken = default);
        //   Task<Result> DeleteAsync(string userId, int visitId, bool isAdmin, CancellationToken cancellationToken = default);
    }
}