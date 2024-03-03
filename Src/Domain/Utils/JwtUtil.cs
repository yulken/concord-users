using concord_users.Src.Domain.Entities;
using JWT.Algorithms;
using JWT.Builder;

namespace concord_users.Src.Domain.Util
{
    public class JwtUtil
    {
        private static readonly string _appName = "concord-users";
        private static readonly int _expirationHours = 1;
        public static string GenerateToken(User user)
        {
            return JwtBuilder.Create()
                .Issuer(_appName)
                .Subject(user.Login)
                .AddClaim("email", user.Email)
                .AddClaim("name", user.Name)
                .AddClaim("login", user.Login)
                .AddClaim("profile_picture", user.ProfilePictureUrl)
                .IssuedAt(DateTime.Now)
                .ExpirationTime(DateTime.Now.AddHours(_expirationHours))
                .WithAlgorithm(new HMACSHA256Algorithm())
                .WithSecret("secret")
                .Encode();
        }
    }
}
