namespace Roshetta.BLL.Errors
{
    public static class VisitErrors
    {
        public static Error DayFull
            = new Error("Visit.Full", "This day is full.", ErrorType.BadRequest);
    }
}