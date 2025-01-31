using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ToDoList.Application.Abstractions.Authentication;
using ToDoList.Domain.Users;

namespace ToDoList.Infrastructure.Authentication;

public class AuthenticationService : IAuthenticationService
{
    public string GenerateAccessToken(User user, Role role)
    {
        IEnumerable<Claim> claims = new List<Claim>
        {
            new (ClaimTypes.NameIdentifier, user.Id.ToString()),
            new (ClaimTypes.Name, user.FirstName),
            new (ClaimTypes.Email, user.Email),
            new (ClaimTypes.Role, role.Name),
            new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET")));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        var tokenDescriptor = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(15),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
    }
}