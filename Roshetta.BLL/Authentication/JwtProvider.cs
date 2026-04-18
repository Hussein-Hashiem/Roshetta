using System.Text.Json;

namespace Roshetta.BLL.Authentication
{
    public class JwtProvider : IJwtProvider
    {
        public (string token, int expiresIn) GenerateToken(ApplicationUser user, IEnumerable<string> roles)
        {
            Claim[] claims = [
            new (JwtRegisteredClaimNames.Sub, user.Id),
            new (JwtRegisteredClaimNames.Email, user.Email!),
            new (JwtRegisteredClaimNames.GivenName, user.Name),
            new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new (nameof(roles), JsonSerializer.Serialize(roles), JsonClaimValueTypes.JsonArray),
            ];

            var symmeticSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("KTVcuuOTiQkGaFkwtoUe7BKR8rrE7CKo"));
            var signingCredentials = new SigningCredentials(symmeticSecurityKey, SecurityAlgorithms.HmacSha256);
          
            var expiresIn = 3600;
            var expirationDate = DateTime.UtcNow.AddMinutes(expiresIn);

            var token = new JwtSecurityToken(
                issuer: "RoshettaApp",
                audience: "Roshetta users",
                claims: claims,
                expires: expirationDate,
                signingCredentials: signingCredentials
            ); 

            return (token: new JwtSecurityTokenHandler().WriteToken(token), expiresIn: expiresIn * 60);
        }
    }
}
