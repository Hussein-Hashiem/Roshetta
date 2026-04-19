namespace Roshetta.BLL.Service.Abstraction
{
    public interface IDepartmentService
    {
        public Task<IEnumerable<string>> GetAll(CancellationToken cancellationToken = default);
    }
}
