using System.ComponentModel.DataAnnotations;

namespace concord_users.Src.Infra.Http.Dtos.Auth
{
    public class AuthRequestDTO
    {
        [Required]
        public required string Login { get; set; }
        [Required]
        public required string Password { get; set; }
    }
}
