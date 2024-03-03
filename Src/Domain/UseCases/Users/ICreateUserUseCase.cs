using concord_users.Src.Domain.UseCases.Users.Input;

namespace concord_users.Src.Domain.UseCases.Users
{
    public interface ICreateUserUseCase
    {
        public string Execute(CreateUserInput createUserInput);
    }
}
