using System.Text.Json.Serialization;

namespace Roshetta.BLL.Contract.Patient
{
    public record UpdatePatientRequestDto(
        string Name,
        string PhoneNumber,
        DateOnly DateOfBirth,
        [property: JsonConverter(typeof(JsonStringEnumConverter))]
        Gender Gender
    );
}