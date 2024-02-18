using concord_users.Src.Domain.Entities;

namespace concord_users.Src.Domain.UseCases
{
    public interface IFindUserUseCase
    {
        public User? Execute(long id);
        public User? Execute(string uuid);
    }
}
