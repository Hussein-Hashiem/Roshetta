namespace Roshetta.DAL.Entities
{
    public class MedicalRecord
    {
        public int Id { get; set; }
        public string Diagnosis { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public string Prescription { get; set; } = string.Empty;
        public Visit Visit { get; set; } = default!;
    }
}