using concord_users.Src.Domain.Entities;

namespace concord_users.Src.Domain.UseCases.Friends
{
    public interface IAddFriendUseCase
    {
        bool Execute(Token token, string friendUuid);
    }
}
