using concord_users.Domain.Entities;
using concord_users.Domain.Ports;

namespace concord_users.Domain.UseCases.Impl
{
    public class FindUserUseCase(
        IFindUserPort findUserPort
        ) : IFindUserUseCase
    {
        private readonly IFindUserPort _findUserPort = findUserPort;

        public User? Execute(long id)
        {
            return _findUserPort.Execute(id);
        }
    }
}
