namespace Roshetta.DAL.Repo.Abstraction
{
    public interface IPatientRepo
    {
        Task AddAsync(Patient patient, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
        IQueryable<Patient> GetAllAsync();
        IQueryable<Patient> GetPatientByUserId(string userId);
    }
}
