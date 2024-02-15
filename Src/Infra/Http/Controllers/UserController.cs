using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using concord_users.Src.Domain.Entities;
using concord_users.Src.Domain.UseCases;
using concord_users.Src.Infra.Http.Dtos;
using concord_users.Src.Domain.UseCases.Input;

namespace concord_users.Src.Infra.Http.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController(
        ILogger<UsersController> logger,
        IMapper mapper,
        IListUsersUseCase listUsers,
        ICreateUserUseCase createUser,
        IFindUserUseCase findUser
        ) : ControllerBase
    {
        private readonly ILogger<UsersController> _logger = logger;
        private readonly IMapper _mapper = mapper;
        private readonly IListUsersUseCase _listUsers = listUsers;
        private readonly ICreateUserUseCase _createUser = createUser;
        private readonly IFindUserUseCase _findUser = findUser;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ListUserResponse Index()
        {
            _logger.LogInformation("Fetching users");
            return new ListUserResponse(_listUsers.Execute());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public User? Find(long id)
        {
            _logger.LogInformation("Fetching user by id {}", id);
            return _findUser.Execute(id);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status409Conflict)]
        public CreateUserResponseDTO Create(CreateUserRequestDTO createUserRequest)
        {
            _logger.LogInformation("Create new user with name {}", createUserRequest.Name);
            string uuid = _createUser.Execute(_mapper.Map<CreateUserInput>(createUserRequest));
            return new CreateUserResponseDTO(uuid);
        }
    }
}