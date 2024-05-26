using concord_users.Src.Domain.Entities;
using concord_users.Src.Domain.Exceptions;
using concord_users.Src.Domain.Ports.Persistence;
using concord_users.Src.Domain.UseCases.Users.Input;

namespace concord_users.Src.Domain.UseCases.Users.Impl
{
    public class DeleteUserUseCase(
        IUserPersistencePort userPersistencePort
        ) : IDeleteUserUseCase
    {

        private readonly IUserPersistencePort _userPersistencePort = userPersistencePort;
        public bool Execute(DeleteUserInput input)
        {
            Token token = input.Token;
            string uuid = input.Uuid;

            if ( token.Uuid.ToString() != uuid)
            {
                throw new UnauthorizedException("Logged user differs from user to be deleted");
            }
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
