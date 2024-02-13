using concord_users.Domain.Entities;
using concord_users.Domain.Ports;

namespace concord_users.Domain.UseCases.Impl
{
    public class ListUsers(IUserDataPort userDataPort): IListUsers
    {
        private readonly IUserDataPort _userDataPort = userDataPort;
        public List<User> Execute()
        {
            return _userDataPort.FindAll();
        }
    }
}
