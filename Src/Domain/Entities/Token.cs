using JWT.Algorithms;
using JWT.Builder;

namespace concord_users.Src.Domain.Entities
{
    public class Token(User user)
    {
        private static readonly string _appName = "concord-users";
        private static readonly int _expirationHours = 1;

        public readonly DateTime ExpirationDate = DateTime.UtcNow.AddHours(_expirationHours);
        private readonly User _user = user;

        public string Generate()
        {
            return JwtBuilder.Create()
                .Issuer(_appName)
                .Subject(_user.Login)
                .AddClaim("email", _user.Email)
                .AddClaim("name", _user.Name)
                .AddClaim("login", _user.Login)
                .AddClaim("profile_picture", _user.ProfilePictureUrl)
                .IssuedAt(DateTime.Now)
                .ExpirationTime(ExpirationDate)
                .WithAlgorithm(new HMACSHA256Algorithm())
                .WithSecret("secret")
                .Encode();
        }
    }
}
