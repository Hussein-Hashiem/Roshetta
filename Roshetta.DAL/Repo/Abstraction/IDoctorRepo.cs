namespace Roshetta.DAL.Repo.Abstraction
{
    public interface IDoctorRepo
    {
        Task AddAsync(Doctor doctor);
        IQueryable<Doctor> GetDoctorByUserId(string userId);
        IQueryable<Doctor> GetAll(CancellationToken cancellationToken = default);

    }
}
