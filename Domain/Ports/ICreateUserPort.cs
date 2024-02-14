using concord_users.Domain.Entities;

namespace concord_users.Domain.Ports
{
    public interface ICreateUserPort
    {
        User Execute(User user);
    }
}
