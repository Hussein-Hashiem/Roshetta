namespace Roshetta.BLL.Contract.Patient
{
    public record PatientDto(
       string Name,
       string PhoneNumber,
       DateOnly DateOfBirth,
       string Gender
    );
}
