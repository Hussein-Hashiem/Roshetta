namespace Roshetta.BLL.Errors
{
    public static class VisitErrors
    {
        public static Error DayFull
            = new Error("Visit.Full", "This day is full.", ErrorType.BadRequest);

        public static Error NotFound
            = new Error("Visit.NotFound", "Visit not found", ErrorType.NotFound);

    }
}