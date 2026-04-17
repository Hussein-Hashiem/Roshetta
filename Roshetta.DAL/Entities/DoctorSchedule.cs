namespace Roshetta.DAL.Entities
{
    public class DoctorSchedule
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public int MaxVisit { get; set; }
        public int DoctotId { get; set; }
        public Doctor Doctor { get; set; } = default!;
    }
}
