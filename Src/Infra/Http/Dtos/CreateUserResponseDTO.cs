namespace concord_users.Src.Infra.Http.Dtos
{
    public class CreateUserResponseDTO(string uuid)
    {
        public string Uuid { get; set; } = uuid;
    }
}
