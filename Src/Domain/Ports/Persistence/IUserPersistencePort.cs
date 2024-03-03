using concord_users.Src.Domain.Entities;
using concord_users.Src.Domain.UseCases.Users.Input;

namespace concord_users.Src.Domain.Ports.Persistence
{
    public interface IUserPersistencePort
    {
        User Create(User user);
        List<User> FindAll(FindUsersInput input, Pagination pagination);
        User? FindById(long id);
        User? FindByUuid(string uuid);
        User? FindByEmailOrLogin(string email, string login);
        User? Update(string uuid, User user);
        User? FindWithLoginAndPasword(string login, string password);
    }
}
