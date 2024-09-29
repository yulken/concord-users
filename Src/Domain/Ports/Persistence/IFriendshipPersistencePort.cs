using concord_users.Src.Domain.Entities;

namespace concord_users.Src.Domain.Ports.Persistence
{
    public interface IFriendshipPersistencePort
    {
        UserFriends FindUserFriends(string uuid);
    }
}
