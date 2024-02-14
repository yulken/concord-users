using concord_users.Domain.Entities;

namespace concord_users.Domain.Ports
{
    public interface IFindUserPort
    {
        User? Execute(long id);
    }
}
