using concord_users.Src.Infra;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Text;

namespace concord_users.Src.Domain.Entities
{
    public class Token
    {
        public static readonly int _expirationHours = 1;
        public readonly string JwtBearer;
        public readonly DateTime ExpirationDate;
        public readonly Guid Uuid;

        public Token(User user) 
        {
            ExpirationDate = DateTime.UtcNow.AddHours(_expirationHours);
            Uuid = user.Uuid;

            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new("sub", user.Uuid.ToString()),
                    new(ClaimTypes.Name, user.Login),
                    new(ClaimTypes.Email,user.Email),
                    new(ClaimTypes.GivenName, user.Name)

                }),
                Expires = ExpirationDate,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes(AppConfig.AuthSecret())), 
                    SecurityAlgorithms.HmacSha256Signature),
                IssuedAt = DateTime.UtcNow,
                Issuer = AppConfig.AuthApp()
            };

            JwtSecurityTokenHandler tokenHandler = new();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            JwtBearer = tokenHandler.WriteToken(token);
        }

        public Token(string bearerJwt)
        {
            var handler = new JwtSecurityTokenHandler();
            JwtSecurityToken jsonToken = handler.ReadJwtToken(bearerJwt);
            ExpirationDate = jsonToken.ValidTo;
            Uuid = Guid.Parse(jsonToken.Subject);
            JwtBearer = bearerJwt;
        }
    }
}
