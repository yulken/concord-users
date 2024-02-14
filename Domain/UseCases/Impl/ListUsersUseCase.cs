using concord_users.Domain.Entities;
using concord_users.Domain.Ports;

namespace concord_users.Domain.UseCases.Impl
{
    public class ListUsersUseCase(IListUserPort listUserPort): IListUsersUseCase
    {
        private readonly IListUserPort _listUserPort = listUserPort;
        public List<User> Execute()
        {
            return _listUserPort.Execute();
        }
    }
}
