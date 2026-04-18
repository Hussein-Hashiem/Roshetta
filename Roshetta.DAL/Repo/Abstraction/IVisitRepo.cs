namespace Roshetta.DAL.Repo.Abstraction
{
    public interface IVisitRepo
    {
        Task AddAsync(Visit visit, CancellationToken cancellationToken);
        Task UpdateAsync(Visit visit, CancellationToken cancelToken);
        Task DeleteAsync(int visitId, CancellationToken cancellationToken = default);
        IQueryable<Visit> GetAll();
        IQueryable<Visit> GetById(int visitId);
        Task<int> GetPatientCountOnDay(int doctorId, DateOnly date);
    }
}