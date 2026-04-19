using System.Text.Json.Serialization;

namespace Roshetta.BLL.Contract.Visit
{
    public record VisitResponseDto(
        int Id,
        DateOnly Date,
        string Name,
        string PhoneNumber,
        [property: JsonConverter(typeof(JsonStringEnumConverter))]
        Status Status
    );
}