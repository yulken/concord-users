using concord_users.Domain.UseCases.Input;

namespace concord_users.Domain.UseCases
{
    public interface ICreateUserUseCase
    {
        public string Execute(CreateUserInput createUserInput);
    }
}
