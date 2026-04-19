namespace Roshetta.DAL.Entities
{
    public class Doctor
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; } = false;
        public decimal? Price { get; set; } 
        public string Location { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Inof { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public ApplicationUser User { get; set; } = default!;
        public ICollection<Visit> Visits { get; set; } = [];
        public ICollection<DoctorSchedule> DoctorSchedules { get; set; } = [];
    }
}