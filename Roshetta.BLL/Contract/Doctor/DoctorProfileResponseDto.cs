using Azure.Core;

namespace Roshetta.BLL.Contract.Doctor
{
    public record DoctorProfileResponseDto(
        string DoctorId,
        string Name, 
        string Info,
        string Department,
        string Location,
        string PhoneNumber,
        decimal? Price,
        DateOnly DateOfBirth
    );
}


