namespace Roshetta.BLL.Contract.Doctor
{
    public record DoctorResponseDto(
        string UserId,
        string Name,
        string Department,
        string Location,
        decimal? Price,
        string Info,
        string PhoneNumber
    );
}