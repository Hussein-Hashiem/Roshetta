namespace Roshetta.DAL.Repo.Abstraction
{
    public interface IPatientRepo
    {
        Task AddAsync(Patient patient, CancellationToken cancellationToken = default);
        Task UpdateAsync(string userId, Patient patient, CancellationToken cancellationToken = default);
        Task DeleteAsync(string userId, CancellationToken cancellationToken = default);
        IQueryable<Patient> GetAll(CancellationToken cancellationToken = default);
        IQueryable<Patient> GetPatientByUserId(string userId, CancellationToken cancellationToken = default);
        //IQueryable<Patient> GetUserByPatientId(string userId, CancellationToken cancellationToken = default);
    }
}
