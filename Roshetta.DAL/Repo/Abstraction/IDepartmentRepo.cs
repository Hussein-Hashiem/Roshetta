namespace Roshetta.DAL.Repo.Abstraction
{
    public interface IDepartmentRepo
    {
        Task<IEnumerable<string>> GetAll(CancellationToken cancellationToken = default);
    }
}
