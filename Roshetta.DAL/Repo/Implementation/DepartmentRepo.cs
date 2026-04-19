namespace Roshetta.DAL.Repo.Implementation
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<string>> GetAll(CancellationToken cancellationToken = default)
        {
            return await _context.Departments.Select(x => x.Name).ToListAsync(cancellationToken);
        }
    }
}
