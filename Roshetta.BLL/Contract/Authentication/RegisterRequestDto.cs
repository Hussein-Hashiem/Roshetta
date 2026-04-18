namespace Roshetta.BLL.Contract.Authentication
{
    public record RegisterRequestDto (
        string Email,
        string Password,
        string Name,
        string PhoneNumber,
        DateOnly DateOfBirth
    );
}
