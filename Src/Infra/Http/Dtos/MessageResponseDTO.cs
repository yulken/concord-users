namespace concord_users.Src.Infra.Http.Dtos
{
    public class MessageResponseDTO(string message)
    {
        public string Message { get; set; } = message;
    }
}
