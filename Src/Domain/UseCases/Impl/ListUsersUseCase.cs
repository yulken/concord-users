using concord_users.Src.Domain.Entities;
using concord_users.Src.Domain.Ports.Persistence;

namespace concord_users.Src.Domain.UseCases.Impl
{
    public class ListUsersUseCase(IUserPersistencePort userPersistencePort) : IListUsersUseCase
    {
        private readonly IUserPersistencePort _userPersistencePort = userPersistencePort;
        public List<User> Execute()
        {
            return _userPersistencePort.FindAll();
        }
    }
}
