using concord_users.Src.Domain.Entities;

namespace concord_users.Src.Domain.UseCases
{
    public interface IListUsersUseCase
    {
        List<User> Execute();
    }
}
