namespace concord_users.Src.Infra.Http.Dtos
{
    public class UserDTO
    {
        public string Uuid { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Status { get; set; }
        public string ProfilePictureUrl { get; set; }
    }
}
