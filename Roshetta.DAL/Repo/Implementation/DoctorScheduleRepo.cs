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

        public IQueryable<DoctorSchedule> GetAll()
        {
            return _context.DoctorSchedules.Where(d => !d.IsDeleted).AsNoTracking();
        }

        public IQueryable<DoctorSchedule> GetById(int id)
        {
            return _context.DoctorSchedules.Where(d => d.Id == id).AsNoTracking();
        }

        public int GetMaxVisit(int doctorId, string day)
        {
            return _context.DoctorSchedules.FirstOrDefault(d => d.Day == day && d.DoctorId == doctorId)!.MaxVisit;
        }

        public async Task UpdateAsync(DoctorSchedule doctorSchedule, CancellationToken cancellationToken)
        {
            await _context.DoctorSchedules.Where(d => d.Id == doctorSchedule.Id)
                .ExecuteUpdateAsync(setter => setter
                .SetProperty(p => p.StartTime, doctorSchedule.StartTime)
                .SetProperty(p => p.EndTime, doctorSchedule.EndTime)
                .SetProperty(p => p.Day, doctorSchedule.Day)
                .SetProperty(p => p.MaxVisit, doctorSchedule.MaxVisit));
        }
    }
}
