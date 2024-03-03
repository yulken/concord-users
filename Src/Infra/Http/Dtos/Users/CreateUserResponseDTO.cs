namespace concord_users.Src.Infra.Http.Dtos.Users
{
    public class CreateUserResponseDTO(string uuid)
    {
        public string Uuid { get; set; } = uuid;
    }
}
