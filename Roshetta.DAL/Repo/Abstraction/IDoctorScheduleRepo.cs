namespace Roshetta.DAL.Repo.Abstraction
{
    public interface IDoctorScheduleRepo
    {
        Task UpdateAsync(DoctorSchedule doctorSchedule, int doctorId, CancellationToken cancellationToken);
        Task AddDaysAsync(List<DoctorSchedule> doctorSchedules);
        IQueryable<DoctorSchedule> GetAllSchedulesForDoctor(int id);
        Task<int> GetMaxVisit(int doctorId, WeekDay day);
        Task<bool> IsVacation(int doctorId, WeekDay day);
    }
}
