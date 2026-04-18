namespace Roshetta.DAL.Entities
{
    public class Patient
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string UserId { get; set; } = string.Empty;
        public ApplicationUser User { get; set; } = default!;
        public ICollection<Visit> Visits { get; set; } = [];
    }
}
