namespace Roshetta.BLL.Service.Abstraction
{
    public interface IVisitService
    {
        Task<Result> AddAsync(string userId, AddVisitRequestDto request, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(string userId, int visitId, UpdateVisitRequestDto request, CancellationToken cancellationToken = default);
        Task<Result> DeleteAsync(string userId, int visitId, CancellationToken cancellationToken = default);
        Task<Result<IEnumerable<VisitResponseDto>>> GetAllAsync(string userId,CancellationToken cancellation = default);
        Task<Result<VisitResponseDto>> GetByIdAsync(int visitId, CancellationToken cancellation = default);
    }
}