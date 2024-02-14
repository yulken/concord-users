using System.ComponentModel.DataAnnotations.Schema;

namespace concord_users.Infra.Data.Models
{
    [Table("users")]
    public class UserModel : BaseModel
    {
        [Column("id")]
        public long Id { get; set; }
        
        [Column("uuid")]
        public string Uuid { get; set; }
        
        [Column("name")]
        public string Name { get; set; }
        
        [Column("email")]
        public string Email { get; set; }
        
        [Column("password")]
        public string Password { get; set; }

        [Column("login")]
        public string Login { get; set; }
        
        [Column("profile_picture_url")]
        public string ProfilePictureUrl { get; set; }

        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }
    }
}
