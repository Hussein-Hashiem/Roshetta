namespace Roshetta.DAL.Entities
{
    public class Visit
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; } = false;
        public int PatientId { get; set; }
        public Patient Patient { get; set; } = default!;
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; } = default!;
        public MedicalRecord? MedicalRecord { get; set; }
    }
}
