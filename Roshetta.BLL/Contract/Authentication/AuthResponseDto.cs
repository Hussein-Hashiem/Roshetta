namespace Roshetta.BLL.Contract.Authentication
{
    public record AuthResponseDto(
        string Id,
        string? Email,
        string Name,
        string Token,
        string Role,
        int ExpiresIn
    );
}
