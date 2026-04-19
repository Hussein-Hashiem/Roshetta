namespace Roshetta.DAL.Repo.Abstraction
{
    public interface IDoctorRepo
    {
        Task<int> AddAsync(Doctor doctor);
        IQueryable<Doctor> GetDoctorByUserId(string userId);

    }
}
