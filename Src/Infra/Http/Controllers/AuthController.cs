using AutoMapper;
using concord_users.Src.Domain.UseCases.Auth;
using concord_users.Src.Infra.Http.Dtos;
using concord_users.Src.Infra.Http.Dtos.Auth;
using Microsoft.AspNetCore.Authorization;
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
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status500InternalServerError)]
        public ActionResult<AuthResponseDTO> Auth(AuthRequestDTO authRequest)
        {
            _logger.LogInformation("User {} attempting login", authRequest.Login);
            return _mapper.Map<AuthResponseDTO>(_authenticateUseCase.Execute(authRequest.Login, authRequest.Password));
        }

    }
}