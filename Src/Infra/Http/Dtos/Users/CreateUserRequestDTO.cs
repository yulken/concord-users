using System.ComponentModel.DataAnnotations;
namespace concord_users.Src.Infra.Http.Dtos.Users
{
    public class CreateUserRequestDTO(
        string name,
        string email,
        string password,
        string login
        )
    {
        [Required]
        [MinLength(2)]
        [MaxLength(60)]
        public string Name { get; set; } = name;
        [Required]
        [MinLength(2)]
        [MaxLength(60)]
        [EmailAddress]
        public string Email { get; set; } = email;
        [Required]
        [MinLength(2)]
        [MaxLength(60)]
        public string Password { get; set; } = password;
        [Required]
        [MinLength(2)]
        [MaxLength(60)]
        public string Login { get; set; } = login;

    }
}
