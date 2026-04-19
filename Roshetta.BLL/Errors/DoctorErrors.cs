namespace Roshetta.BLL.Errors
{
    public static class DoctorErrors
    {
        public static Error NotFound
            = new Error("Doctor.NotFound", "Doctor not found", ErrorType.NotFound);
    }
}