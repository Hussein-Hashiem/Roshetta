namespace Roshetta.DAL.Entities
{
    public class Doctor
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; } = false;
        public float Price { get; set; }
        public string UserId { get; set; } = string.Empty;
        public ApplicationUser User { get; set; } = default!;
        public ICollection<Visit> Visits { get; set; } = [];
        public ICollection<DoctorSchedule> DoctorSchedules { get; set; } = [];
        public int? DepartmentId { get; set; }
        public Department Department { get; set; } = default!;
    }
}