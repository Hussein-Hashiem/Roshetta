using System.Text.Json.Serialization;

namespace Roshetta.BLL.Contract.Profile
{
    public record ProfileResponseDto(
        string UserId,
        string Name,
        string PhoneNumber,
        DateOnly DateOfBirth,
        [property: JsonConverter(typeof(JsonStringEnumConverter))]
        Gender Gender
    );
}