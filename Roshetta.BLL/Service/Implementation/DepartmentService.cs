namespace Roshetta.BLL.Service.Implementation
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepo _departmentRepo;

        public DepartmentService(IDepartmentRepo departmentRepo)
        {
            _departmentRepo = departmentRepo;
        }

        public Task<IEnumerable<string>> GetAll(CancellationToken cancellationToken = default)
        {
            return _departmentRepo.GetAll(cancellationToken);
        }
    }
}
