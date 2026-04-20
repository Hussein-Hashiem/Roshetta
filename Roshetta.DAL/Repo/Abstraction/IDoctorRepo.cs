namespace Roshetta.DAL.Repo.Abstraction
{
    public interface IDoctorRepo
    {
        Task AddAsync(Doctor doctor);
        IQueryable<Doctor> GetDoctorByUserId(string userId, CancellationToken cancellationToken = default);
        Task UpdateAsync(string userId, Doctor request);
    }
}
