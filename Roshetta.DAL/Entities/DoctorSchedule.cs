namespace Roshetta.DAL.Entities
{
    public class DoctorSchedule
    {
        public int Id { get; set; }
        public WeekDay Day { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        //public int MaxVisit { get; set; }
        public int AverageConsultationTime { get; set; }
        public bool IsVacation { get; set; } = false;
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; } = default!;
    }
}
