using System.Text.Json.Serialization;

namespace Roshetta.BLL.Contract.Visit
{
    public record UpdateVisitRequestDto(
        [property: JsonConverter(typeof(JsonStringEnumConverter))]
        Status Status
    );
}