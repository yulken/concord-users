using AutoMapper;
using concord_users.Src.Domain.Entities;
using concord_users.Src.Domain.UseCases.Auth;
using concord_users.Src.Infra.Http.Dtos;
using concord_users.Src.Infra.Http.Dtos.Auth;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace concord_users.Src.Infra.Http.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController(
        ILogger<AuthController> logger,
        IMapper mapper,
        IAuthenticateUseCase authenticateUseCase
        ) : ControllerBase
    {
        private readonly ILogger<AuthController> _logger = logger;
        private readonly IMapper _mapper = mapper;
        private readonly IAuthenticateUseCase _authenticateUseCase = authenticateUseCase;


        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status409Conflict)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status500InternalServerError)]
        public ActionResult<AuthResponseDTO> Create(AuthRequestDTO authRequest)
        {
            Token token = _authenticateUseCase.Execute(authRequest.Login, authRequest.Password);
            return new AuthResponseDTO(token.Generate(), token.ExpirationDate);
        }

    }
}