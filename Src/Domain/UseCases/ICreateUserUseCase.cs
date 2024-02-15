using concord_users.Src.Domain.UseCases.Input;

namespace concord_users.Src.Domain.UseCases
{
    public interface ICreateUserUseCase
    {
        public string Execute(CreateUserInput createUserInput);
    }
}
