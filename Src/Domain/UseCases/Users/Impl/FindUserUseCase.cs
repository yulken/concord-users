using concord_users.Src.Domain.Entities;
using concord_users.Src.Domain.Ports.Persistence;

namespace concord_users.Src.Domain.UseCases.Users.Impl
{
    public class FindUserUseCase(
        IUserPersistencePort userPersistencePort
        ) : IFindUserUseCase
    {
        private readonly IUserPersistencePort _userPersistencePort = userPersistencePort;

        public User? Execute(string uuid)
        {
            return _userPersistencePort.FindByUuid(uuid);
        }
    }
}
