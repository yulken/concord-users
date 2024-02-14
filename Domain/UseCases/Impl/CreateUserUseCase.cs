using AutoMapper;
using concord_users.Domain.Entities;
using concord_users.Domain.Ports;
using concord_users.Domain.UseCases.Input;

namespace concord_users.Domain.UseCases.Impl
{
    public class CreateUserUseCase(
        ILogger<CreateUserUseCase> logger,
        ICreateUserPort createUserPort,
        IMapper mapper
        ): ICreateUserUseCase
    {
        private readonly ILogger<CreateUserUseCase> _logger = logger;
        private readonly IMapper _mapper = mapper;
        private readonly ICreateUserPort _createUserPort = createUserPort;

        public string Execute(CreateUserInput createUserInput)
        {
            _logger.LogInformation("createUserInput {}", createUserInput);
            User newUser = _createUserPort.Execute(_mapper.Map<User>(createUserInput));
            return newUser.Uuid;
        }
    }
}
