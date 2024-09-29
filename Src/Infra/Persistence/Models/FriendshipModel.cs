using System.ComponentModel.DataAnnotations.Schema;

namespace concord_users.Src.Infra.Persistence.Models
{
    [Table("friendships")]
    public class FriendshipModel: BaseModel
    {
        [Column("sender_id")]
        public required long SenderId { get; set; }

        [Column("recipient_id")]
        public required long RecipientId { get; set; }
        
        [Column("status")]
        public required string Status { get; set; }

        [Column("accepted_at")]
        public DateTime? AcceptedAt { get; set; }

        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }
    }
}
