using AutoMapper;
using concord_users.Src.Domain.Entities;
using concord_users.Src.Domain.Exceptions;
using concord_users.Src.Domain.Enums;
using concord_users.Src.Domain.Ports.Persistence;
using concord_users.Src.Domain.UseCases.Input;

namespace concord_users.Src.Domain.UseCases.Impl
{
    public class CreateUserUseCase(
        ILogger<CreateUserUseCase> logger,
        IUserPersistencePort userPersistencePort,
        IMapper mapper
        ) : ICreateUserUseCase
    {
        private readonly ILogger<CreateUserUseCase> _logger = logger;
        private readonly IMapper _mapper = mapper;
        private readonly IUserPersistencePort _userPersistence = userPersistencePort;

        public string Execute(CreateUserInput createUserInput)
        {
            _logger.LogInformation("createUserInput {}", createUserInput);

            User? foundUser = _userPersistence.FindByEmailOrLogin(createUserInput.Email, createUserInput.Login);

            if (foundUser != null)
            {
                _logger.LogError("Usuário já existe na base");
                throw new ConflictingDataException("Não foi possível registrar usuário");
            }

            User user = _mapper.Map<User>(createUserInput);
            user.Uuid = Guid.NewGuid();
            user.Status = UserStatus.Active;

            User newUser = _userPersistence.Create(user);
            return newUser.Uuid.ToString();
        }
    }
}
