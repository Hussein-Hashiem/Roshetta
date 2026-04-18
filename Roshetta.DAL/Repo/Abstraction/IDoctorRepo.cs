namespace Roshetta.DAL.Repo.Abstraction
{
    internal interface IDoctorRepo
    {
        Task AddAsync(Doctor doctor);
    }
}
