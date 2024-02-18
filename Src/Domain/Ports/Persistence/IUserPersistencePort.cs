using concord_users.Src.Domain.Entities;

namespace concord_users.Src.Domain.Ports.Persistence
{
    public interface IUserPersistencePort
    {
        User Create(User user);
        List<User> FindAll();
        User? FindById(long id);
        User? FindByUuid(string uuid);
        User? FindByEmailOrLogin(string email, string login);
        User? Update(string uuid, User user);
    }
}
