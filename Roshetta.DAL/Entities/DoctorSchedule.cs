namespace Roshetta.DAL.Entities
{
    public class DoctorSchedule
    {
        public int Id { get; set; }
        public string Day { get; set; } = string.Empty;
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public int MaxVisit { get; set; }
        public bool IsDeleted { get; set; } = false;
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; } = default!;
    }
}
