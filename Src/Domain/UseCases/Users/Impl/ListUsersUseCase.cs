using concord_users.Src.Domain.Entities;
using concord_users.Src.Domain.Ports.Persistence;
using concord_users.Src.Domain.UseCases.Users.Input;

namespace concord_users.Src.Domain.UseCases.Users.Impl
{
    public class ListUsersUseCase(IUserPersistencePort userPersistencePort) : IListUsersUseCase
    {
        private readonly IUserPersistencePort _userPersistencePort = userPersistencePort;
        public List<User> Execute(FindUsersInput input, Pagination pagination)
        {
            return _userPersistencePort.FindAll(input, pagination);
        }
    }
}
