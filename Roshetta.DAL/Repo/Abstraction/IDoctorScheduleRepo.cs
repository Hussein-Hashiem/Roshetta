using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Roshetta.DAL.Repo.Abstraction
{
    public interface IDoctorScheduleRepo
    {
        Task UpdateAsync(DoctorSchedule doctorSchedule, CancellationToken cancellationToken);
        Task AddDaysAsync(List<DoctorSchedule> doctorSchedules);
        IQueryable<DoctorSchedule> GetAllSchedulesForDoctor(int id);
        Task<int> GetMaxVisit(int doctorId, WeekDay day);
    }
}
