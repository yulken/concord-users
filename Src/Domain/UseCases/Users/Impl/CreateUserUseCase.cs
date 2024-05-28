using concord_users.Src.Domain.Entities;
using concord_users.Src.Domain.Exceptions;
using concord_users.Src.Domain.Ports.Persistence;
using concord_users.Src.Domain.UseCases.Users.Input;

namespace concord_users.Src.Domain.UseCases.Users.Impl
{
    public class CreateUserUseCase(
        ILogger<CreateUserUseCase> logger,
        IUserPersistencePort userPersistencePort
        ) : ICreateUserUseCase
    {
        private readonly ILogger<CreateUserUseCase> _logger = logger;
        private readonly IUserPersistencePort _userPersistence = userPersistencePort;

        public string Execute(CreateUserInput createUserInput)
        {
            _logger.LogInformation("createUserInput {}", createUserInput);

            User? foundUser = _userPersistence.FindByEmailOrLogin(createUserInput.Email, createUserInput.Login);

            if (foundUser != null)
            {
                _logger.LogError("User already exists");
                throw new ConflictingDataException("Unable to register user");
            }

            User userModel = new(
                createUserInput.Name,
                createUserInput.Email,
                createUserInput.Login,
                createUserInput.Password
            );

            User newUser = _userPersistence.Create(userModel);
            return newUser.Uuid.ToString();
        }
    }
}
