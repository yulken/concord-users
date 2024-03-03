using concord_users.Src.Domain.Entities;

namespace concord_users.Src.Domain.UseCases.Auth
{
    public interface IAuthenticateUseCase
    {
        Token Execute(string login, string password);
    }
}
