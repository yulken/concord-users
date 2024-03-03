using concord_users.Src.Domain.Entities;
using concord_users.Src.Domain.Enums;
using concord_users.Src.Domain.Exceptions;
using concord_users.Src.Domain.Ports.Persistence;
using concord_users.Src.Domain.UseCases.Users.Input;
using static BCrypt.Net.BCrypt;

namespace concord_users.Src.Domain.UseCases.Auth.Impl
{
    public class AuthenticateUseCase(
        IUserPersistencePort userPersistence
        ): IAuthenticateUseCase
    {
        private readonly IUserPersistencePort _userPersistence = userPersistence; 
        public Token Execute(string login, string password)
        {
            User user = FindUser(login);

            if(!Verify(password, user.Password))
            {
                throw new ConflictingDataException("Login ou senha são invalidos");
            };

            return new Token(user);
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
