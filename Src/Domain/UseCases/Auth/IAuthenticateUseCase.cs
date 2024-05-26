using concord_users.Src.Domain.Entities;
using concord_users.Src.Infra.Http.Dtos.Auth;

namespace concord_users.Src.Domain.UseCases.Auth
{
    public interface IAuthenticateUseCase
    {
        AuthResponseDTO Execute(string login, string password);
    }
}
