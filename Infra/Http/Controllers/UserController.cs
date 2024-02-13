using Microsoft.AspNetCore.Mvc;
using concord_users.Domain.Entities;
using concord_users.Domain.UseCases;

namespace concord_users.Infra.Http.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController(
        ILogger<UsersController> logger,
        IListUsers listUsers
        ) : ControllerBase
    {
        private readonly ILogger<UsersController> _logger = logger;
        private readonly IListUsers _listUsers = listUsers;

        [HttpGet(Name = "GetUsers")]
        public List<User> Get()
        {
            _logger.LogInformation("Fetching users");
            return _listUsers.Execute();
        }

    }
}