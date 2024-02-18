﻿using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using concord_users.Src.Domain.Entities;
using concord_users.Src.Domain.UseCases;
using concord_users.Src.Infra.Http.Dtos;
using concord_users.Src.Domain.UseCases.Input;
using System.Net.Mime;

namespace concord_users.Src.Infra.Http.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController(
        ILogger<UsersController> logger,
        IMapper mapper,
        IListUsersUseCase listUsers,
        ICreateUserUseCase createUser,
        IFindUserUseCase findUser,
        IDeleteUserUseCase deleteUserUseCase
        ) : ControllerBase
    {
        private readonly ILogger<UsersController> _logger = logger;
        private readonly IMapper _mapper = mapper;
        private readonly IListUsersUseCase _listUsers = listUsers;
        private readonly ICreateUserUseCase _createUser = createUser;
        private readonly IFindUserUseCase _findUser = findUser;
        private readonly IDeleteUserUseCase _deleteUserUseCase = deleteUserUseCase;

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status500InternalServerError)]
        public ActionResult<ListUserResponseDTO> Index()
        {
            _logger.LogInformation("Fetching users");
            List<UserDTO> usersDTO = _mapper.Map<List<User>, List<UserDTO>>(_listUsers.Execute());
            return new ListUserResponseDTO(usersDTO);
        }

        [HttpGet("{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status500InternalServerError)]
        public ActionResult<UserDTO?> Find(long id)
        {
            _logger.LogInformation("Fetching user by id {}", id);
            User? user = _findUser.Execute(id);
            if (user == null)
            {
                return NoContent();
            }

            return _mapper.Map<UserDTO>(user);
        }

        [HttpGet("{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status500InternalServerError)]
        public ActionResult<UserDTO?> FindByUuid(string uuid)
        {
            _logger.LogInformation("Fetching user by uuid {}", uuid);
            User? user = _findUser.Execute(uuid);
            if (user == null)
            {
                return NoContent();
            }

            return _mapper.Map<UserDTO>(user);
        }


        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status409Conflict)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status500InternalServerError)]
        public ActionResult<CreateUserResponseDTO> Create(CreateUserRequestDTO createUserRequest)
        {
            _logger.LogInformation("Create new user with name {}", createUserRequest.Name);
            string uuid = _createUser.Execute(_mapper.Map<CreateUserInput>(createUserRequest));
            return new CreateUserResponseDTO(uuid);
        }


        [HttpDelete("{uuid}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status500InternalServerError)]
        public ActionResult<MessageResponseDTO> Delete(string uuid)
        {
            _logger.LogInformation("Delete user with uuid {}", uuid);
            bool isDeleted = _deleteUserUseCase.Execute(uuid);
            if (!isDeleted)
            {
                return NoContent();
            }
            return new MessageResponseDTO("User successfully deleted");
        }
    }
}