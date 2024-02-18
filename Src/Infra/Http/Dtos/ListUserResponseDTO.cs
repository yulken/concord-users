namespace concord_users.Src.Infra.Http.Dtos
{
    public class ListUserResponseDTO(List<UserDTO> users)
    {
        public List<UserDTO> Users { get; set; } = users;
    }
}
