using concord_users.Src.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace concord_users.Src.Infra.Persistence.Models
{
    [Table("users")]
    public class UserModel : BaseModel
    {

        [Column("id")]
        public required long Id { get; set; }

        [Column("uuid")]
        public required string Uuid { get; set; }

        [Column("name")]
        public required string Name { get; set; }

        [Column("email")]
        public required string Email { get; set; }

        [Column("password")]
        public required string Password { get; set; }

        [Column("login")]
        public required string Login { get; set; }

        [Column("status")]
        public required string Status { get; set; }

        [Column("profile_picture_url")]
        public string? ProfilePictureUrl { get; set; }

        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        public bool IsActive()
        {
            return Status == UserStatusUtil.GetShortValue(UserStatus.Active);
        }
    }
}
