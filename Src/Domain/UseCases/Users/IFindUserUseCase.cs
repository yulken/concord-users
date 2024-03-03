using concord_users.Src.Domain.Entities;

namespace concord_users.Src.Domain.UseCases.Users
{
    public interface IFindUserUseCase
    {
        public User? Execute(string uuid);
    }
}
