
namespace Roshetta.BLL.Contract.DoctorSchedule
{
    public record DoctorScheduleDto(
        int ScheduleId,
        string Day,
        TimeOnly StartTime,
        TimeOnly EndTime,
        bool IsVacation,
        int AverageConsultationTime,
        int MaxVisits 
    );
}
