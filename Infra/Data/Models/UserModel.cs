using System.ComponentModel.DataAnnotations.Schema;

namespace concord_users.Infra.Data.Models
{
    [Table("users")]
    public class UserModel
    {
        [Column("id")]
        public int Id { get; set; }
        
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

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set;}

        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }
    }
}
