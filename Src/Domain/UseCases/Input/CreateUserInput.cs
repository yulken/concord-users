namespace concord_users.Src.Domain.UseCases.Input
{
    public class CreateUserInput(
        string name,
        string email,
        string password,
        string login
        )
    {
        public readonly string Name = name;
        public readonly string Email = email;
        public readonly string Password = password;
        public readonly string Login = login;

        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(Email)}={Email}, " +
                $"{nameof(Login)}={Login}";
        }
    }
}
