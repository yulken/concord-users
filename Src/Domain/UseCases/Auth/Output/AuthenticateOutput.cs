namespace concord_users.Src.Domain.UseCases.Auth.Output
{
    public class AuthenticateOutput(
        string authorization,
        DateTime expiresAt
        )
    {
        public string Authorization { get; set; } = authorization;
        public DateTime ExpiresAt { get; set; } = expiresAt;
    }
}
