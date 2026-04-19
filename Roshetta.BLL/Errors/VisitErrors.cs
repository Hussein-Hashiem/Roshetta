namespace Roshetta.BLL.Errors
{
    public static class VisitErrors
    {
        public static Error DayFull
            = new Error("Visit.Full", "This day is full.", ErrorType.BadRequest);

        public static Error NotFound
            = new Error("Visit.NotFound", "Visit not found", ErrorType.NotFound);

        public static Error Unauthorized
            = new Error("Visit.Unauthorized", "You dont have access to this visit", ErrorType.Unauthorized);
        public static Error AlreadyDeleted
            = new Error("Visit.AlreadyDeleted", "This visit already deleted.", ErrorType.BadRequest);
    }
}