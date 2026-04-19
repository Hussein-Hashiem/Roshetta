namespace Roshetta.BLL.Errors
{
    public static class PatientErrors
    {
        public static Error NotFound
            = new Error("Patient.NotFound", "Patient not found", ErrorType.NotFound);
    }
}