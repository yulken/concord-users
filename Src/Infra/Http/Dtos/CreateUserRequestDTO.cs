namespace concord_users.Src.Infra.Http.Dtos
{
    public class CreateUserRequestDTO(
        string name,
        string email,
        string password,
        string login
        )
    {
        public string Name { get; set; } = name;
        public string Email { get; set; } = email;
        public string Password { get; set; } = password;
        public string Login { get; set; } = login;
   
    }
}
