using concord_users.Domain.Entities;

namespace concord_users.Domain.UseCases
{
    public interface IListUsers
    {
        List<User> Execute();
    }
}
