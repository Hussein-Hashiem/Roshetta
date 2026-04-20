namespace Roshetta.DAL.Repo.Abstraction
{
    public interface IVisitRepo
    {
        Task AddAsync(Visit visit, CancellationToken cancellationToken);
        Task UpdateAsync(Visit visit, CancellationToken cancelToken);
        Task DeleteAsync(int visitId, CancellationToken cancellationToken = default);
        IQueryable<Visit> GetAll(int doctorId);
        IQueryable<Visit> GetPatientVisit(int patientId);
        IQueryable<Visit> GetById(int visitId);
        Task<int> GetPatientCountOnDay(int doctorId, DateOnly date);
        Task<bool> IsExist(int doctorId, int patientId, DateOnly date);
        Task<int> GetConfirmedCount(int doctorId, DateOnly date);
        Task<int> GetNewRequestCount(int doctorId, DateOnly date);
    }
}