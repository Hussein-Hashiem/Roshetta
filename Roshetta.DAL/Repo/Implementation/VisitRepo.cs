namespace Roshetta.DAL.Repo.Implementation
{
    public class VisitRepo : IVisitRepo
    {
        private readonly ApplicationDbContext _dbContext;

        public VisitRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Visit visit, CancellationToken cancellationToken)
        {
            await _dbContext.Visits.AddAsync(visit, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(int visitId, CancellationToken cancellationToken = default)
        {
            await _dbContext.Visits
                .Where(v => v.Id == visitId)
                .ExecuteUpdateAsync(setter =>
                    setter.SetProperty(r => r.IsDeleted, true)
                );
        }

        public IQueryable<Visit> GetAll(int doctorId)
        {
            return _dbContext.Visits
                .Where(v => !v.IsDeleted && v.DoctorId == doctorId)
                .AsNoTracking();
        }

        public IQueryable<Visit> GetById(int visitId)
        {
            return _dbContext.Visits
                .Where(v => v.Id == visitId && !v.IsDeleted)
                .Include(x => x.Patient)
                .ThenInclude(x => x.User)
                .AsNoTracking();
        }

        public async Task<int> GetPatientCountOnDay(int doctorId, DateOnly date)
        {
            return await _dbContext.Visits
                .Where(v => v.DoctorId == doctorId && !v.IsDeleted && date == v.Date).CountAsync();
        }
        public async Task<int> GetNewRequestCount(int doctorId, DateOnly date)
        {
            return await _dbContext.Visits.Where(v => v.DoctorId == doctorId && v.Date == date && v.Status == Status.Pending).CountAsync();
        }
        public async Task<int> GetConfirmedCount(int doctorId, DateOnly date)
        {
            return await _dbContext.Visits.Where(v => v.DoctorId == doctorId && v.Date == date && v.Status == Status.Approved).CountAsync();
        }
        public async Task<bool> IsExist(int doctorId, int patientId, DateOnly date)
        {
            return await _dbContext.Visits
                .Where(v => v.DoctorId == doctorId && !v.IsDeleted && date == v.Date && v.PatientId == patientId).AnyAsync();
        }

        public async Task UpdateAsync(Visit visit, CancellationToken cancelToken)
        {
            await _dbContext.Visits
                    .Where(v => v.Id == visit.Id)
                    .ExecuteUpdateAsync(setter =>
                        setter.SetProperty(f => f.Status, visit.Status).SetProperty(f => f.IsDeleted, visit.IsDeleted));
        }
    }
}