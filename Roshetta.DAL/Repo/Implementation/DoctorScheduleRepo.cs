using System;
using System.Collections.Generic;
using System.Text;

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
                .Select(x => (int)((x.EndTime - x.StartTime).TotalMinutes / x.AverageConsultationTime))
                .FirstOrDefaultAsync();

            return maxVisit;
        }

        public async Task UpdateAsync(DoctorSchedule doctorSchedule, CancellationToken cancellationToken)
        {
            await _context.DoctorSchedules.Where(d => d.Id == doctorSchedule.Id)
                .ExecuteUpdateAsync(setter => setter
                .SetProperty(p => p.StartTime, doctorSchedule.StartTime)
                .SetProperty(p => p.EndTime, doctorSchedule.EndTime)
                .SetProperty(p => p.AverageConsultationTime, doctorSchedule.AverageConsultationTime));
        }
    }
}
