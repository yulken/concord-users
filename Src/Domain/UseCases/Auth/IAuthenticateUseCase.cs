using concord_users.Src.Domain.UseCases.Auth.Output;

namespace concord_users.Src.Domain.UseCases.Auth
{
    public interface IAuthenticateUseCase
    {
        AuthenticateOutput Execute(string login, string password);
    }
}
