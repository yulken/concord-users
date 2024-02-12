using Microsoft.AspNetCore.Mvc;
using concord_users.Entities;

namespace concord_users.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController(ILogger<UsersController> logger) : ControllerBase
    {
        private readonly ILogger<UsersController> _logger = logger;

        [HttpGet(Name = "GetUsers")]
        public User Get()
        {
            User user = new User();
            user.Name = "name";
            user.Email = "email";
            user.Password = "password";
            user.Login = "login";
            user.ProfilePicture = "profile_picture.png";
            return user;
        }
    }
}