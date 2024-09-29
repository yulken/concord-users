using concord_users.Src.Domain.Entities;
using concord_users.Src.Domain.Enums;
using concord_users.Src.Domain.Exceptions;
using concord_users.Src.Domain.Ports.Persistence;
using concord_users.Src.Domain.UseCases.Auth.Output;
using concord_users.Src.Domain.UseCases.Users.Input;

namespace concord_users.Src.Domain.UseCases.Auth.Impl
{
    public class AuthenticateTestEnvUseCase(
        IUserPersistencePort userPersistence
        ) : IAuthenticateUseCase
    {
        private readonly IUserPersistencePort _userPersistence = userPersistence;
        public AuthenticateOutput Execute(string login, string password)
        {
            User user = FindUser(login);

            if (password != "001122")
            {
                throw new ConflictingDataException("Login ou senha são invalidos");
            };
            Token token = new(user);
            return new AuthenticateOutput(token.JwtBearer, token.ExpirationDate);
        }

        private User FindUser(string login)
        {
            FindUsersInput input = new()
            {
                Login = login
            };

            Pagination pagination = new()
            {
                PageSize = 1,
                PageCount = 0,
                OrderBy = OrderByEnum.Desc
            };

            List<User> users = _userPersistence.FindAll(input, pagination);
            if (users.Count == 0)
            {
                throw new ConflictingDataException("Login ou senha são invalidos");
            }

            return users[0];
        }
    }
}
