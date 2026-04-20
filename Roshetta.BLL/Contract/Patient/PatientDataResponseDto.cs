namespace Roshetta.BLL.Contract.Patient
{
    public record PatientDataResponseDto(
        string Name,
        DateOnly DateOfBirth,
        Gender Gender,
        DateOnly Date,
        string PhoneNumber,
        string Email
    );
}