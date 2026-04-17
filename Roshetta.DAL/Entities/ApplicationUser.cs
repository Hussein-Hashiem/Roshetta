namespace Roshetta.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
    }
}
