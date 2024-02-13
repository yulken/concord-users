using concord_users.Domain.Entities;

namespace concord_users.Domain.Ports
{
    public interface IUserDataPort
    {
        User FindById(long id);
        List<User> FindAll();
    }
}
