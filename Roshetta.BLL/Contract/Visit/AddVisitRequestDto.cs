namespace Roshetta.BLL.Contract.Visit
{
    public record AddVisitRequestDto(
        DateOnly Date,
        string DoctorId
    );
}