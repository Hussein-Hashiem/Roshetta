using System.Text.Json.Serialization;

namespace Roshetta.BLL.Contract.Patient
{
    public record PatientVisitResponseDto(
        string DoctorName,
        string DoctorDepartment,
        DateOnly Date,
        [property: JsonConverter(typeof(JsonStringEnumConverter))]
        Status Status
    );
}