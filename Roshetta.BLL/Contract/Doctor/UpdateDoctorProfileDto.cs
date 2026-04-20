namespace Roshetta.BLL.Contract.Doctor
{
    public record UpdateDoctorProfileDto(
        string Name,
        string Info,
        string Department,
        string Location,
        string PhoneNumber,
        decimal? Price,
        DateOnly DateOfBirth
    );
}
