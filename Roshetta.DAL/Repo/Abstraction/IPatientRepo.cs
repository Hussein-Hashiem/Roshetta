namespace Roshetta.DAL.Repo.Abstraction
{
    public interface IPatientRepo
    {
        Task AddAsync(Patient patient);
        IQueryable<Patient> GetPatientByUserId(string userId);
    }
}
