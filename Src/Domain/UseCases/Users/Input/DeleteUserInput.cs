using concord_users.Src.Domain.Entities;

namespace concord_users.Src.Domain.UseCases.Users.Input
{
    public class DeleteUserInput(
        string uuid,
        Token token
        )
    {
        public readonly string Uuid = uuid;
        public readonly Token Token = token;
    }
}
