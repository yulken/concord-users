using AutoMapper;
using concord_users.Src.Domain.UseCases.Auth;
using concord_users.Src.Infra.Http.Dtos.Auth;
using concord_users.Src.Infra.Http.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using concord_users.Src.Domain.Entities;
using concord_users.Src.Domain.UseCases.Friends;

namespace concord_users.Src.Infra.Http.Controllers
{
    [ApiController]
    [Route("friends")]
    public class FriendController(
        ILogger<FriendController> logger,
        IMapper mapper,
        IAddFriendUseCase addFriendUseCase
        ) : ControllerBase
    {
        private readonly ILogger<FriendController> _logger = logger;
        private readonly IMapper _mapper = mapper;
        private readonly IAddFriendUseCase _addFriendUseCase = addFriendUseCase;

        [Authorize]
        [HttpPost("{uuid}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status500InternalServerError)]
        public ActionResult<AuthResponseDTO> Create(
            [FromHeader(Name = "Authorization")] string jwt,
            string friendUuid
            )
        {
            Token token = new(jwt.Split(" ")[1]);
            _logger.LogInformation("User {} adding friend with login {}", token.Uuid, friendUuid);

            return _mapper.Map<AuthResponseDTO>(_addFriendUseCase.Execute(token, friendUuid));
        }
    }
}
