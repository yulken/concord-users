namespace concord_users.Src.Infra.Http.Dtos.Auth
{
    public class AuthResponseDTO(
        string authorization,
        DateTime expiresAt 
        )
    {
        public string Authorization { get; set; } = authorization;
        public DateTime ExpiresAt { get; set; } = expiresAt;
    }
}
