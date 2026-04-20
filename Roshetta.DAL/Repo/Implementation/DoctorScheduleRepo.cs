namespace Roshetta.DAL.Repo.Implementation
{
    public class DoctorScheduleRepo : IDoctorScheduleRepo
    {
        private readonly ApplicationDbContext _context;
        public DoctorScheduleRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddDaysAsync(List<DoctorSchedule> doctorSchedules)
        {
            await _context.DoctorSchedules.AddRangeAsync(doctorSchedules);
            await _context.SaveChangesAsync();
        }

        public IQueryable<DoctorSchedule> GetAllSchedulesForDoctor(int doctorId)
        {
            return _context.DoctorSchedules
                .AsNoTracking()
                .Where(x => x.DoctorId == doctorId);
        }

        public IQueryable<DoctorSchedule> GetById(int id)
        {
            return _context.DoctorSchedules.AsNoTracking().Where(d => d.Id == id);
        }

        public async Task<int> GetMaxVisit(int doctorId, WeekDay day)
        {
            var maxVisit = await _context.DoctorSchedules
                .Where(x => x.DoctorId == doctorId && x.Day == day)
                .Select(x => x.MaxVisit)
                .FirstOrDefaultAsync();

            return maxVisit;
        }

        public async Task<bool> IsVacation(int doctorId, WeekDay day)
        {
            return await _context.DoctorSchedules.AnyAsync(x => x.DoctorId == doctorId && x.IsVacation);
        }

        public async Task UpdateAsync(DoctorSchedule doctorSchedule, int doctorId, CancellationToken cancellationToken)
        {
            await _context.DoctorSchedules
                .Where(d => d.Id == doctorSchedule.Id && d.DoctorId == doctorId)
                .ExecuteUpdateAsync(setter => setter
                .SetProperty(p => p.StartTime, doctorSchedule.StartTime)
                .SetProperty(p => p.EndTime, doctorSchedule.EndTime)
                .SetProperty(p => p.MaxVisit, doctorSchedule.MaxVisit)
                .SetProperty(p => p.IsVacation, doctorSchedule.IsVacation)
                .SetProperty(p => p.AverageConsultationTime, doctorSchedule.AverageConsultationTime));
        }
    }
}
