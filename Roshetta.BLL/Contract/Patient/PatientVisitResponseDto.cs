namespace Roshetta.BLL.Contract.Patient
{
    public record PatientVisitResponseDto(
        string DoctorName,
        string DoctorDepartment,
        DateOnly Date,
        Status Status
    );
}