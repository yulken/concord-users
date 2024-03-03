using concord_users.Src.Domain.Entities;
using concord_users.Src.Domain.Ports.Persistence;

namespace concord_users.Src.Domain.UseCases.Users.Impl
{
    public class DeleteUserUseCase(
        IUserPersistencePort userPersistencePort
        ) : IDeleteUserUseCase
    {

        private readonly IUserPersistencePort _userPersistencePort = userPersistencePort;
        public bool Execute(string uuid)
        {
            User? user = _userPersistencePort.FindByUuid(uuid);
            if (user == null)
            {
                return false;
            }

            user.Deactivate();
            _userPersistencePort.Update(uuid, user);
            return true;
        }
    }
}
