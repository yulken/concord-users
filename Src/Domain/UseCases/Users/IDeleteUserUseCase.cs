using concord_users.Src.Domain.UseCases.Users.Input;

namespace concord_users.Src.Domain.UseCases.Users
{
    public interface IDeleteUserUseCase
    {
        public bool Execute(DeleteUserInput input);
    }
}
