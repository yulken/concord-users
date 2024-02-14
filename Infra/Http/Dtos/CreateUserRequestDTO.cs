namespace concord_users.Infra.Http.Dtos
{
    public class CreateUserRequestDTO(
        string name,
        string email,
        string password,
        string login,
        string profilePicture
        )
    {
        public string Name {get; set;}= name;
        public string Email {get; set;}= email;
        public string Password {get; set;}= password;
        public string Login {get; set;}= login;
        public string ProfilePicture { get; set; } = profilePicture;
    }           
}
