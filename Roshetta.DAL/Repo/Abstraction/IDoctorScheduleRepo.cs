using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Roshetta.DAL.Repo.Abstraction
{
    public interface IDoctorScheduleRepo
    {
        Task UpdateAsync(DoctorSchedule doctorSchedule, CancellationToken cancellationToken);
        IQueryable<DoctorSchedule> GetAll();
        IQueryable<DoctorSchedule> GetById(int id);
    }
}
