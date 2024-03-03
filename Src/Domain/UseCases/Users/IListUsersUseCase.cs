using concord_users.Src.Domain.Entities;
using concord_users.Src.Domain.UseCases.Users.Input;

namespace concord_users.Src.Domain.UseCases.Users
{
    public interface IListUsersUseCase
    {
        List<User> Execute(FindUsersInput input, Pagination pagination);
    }
}
