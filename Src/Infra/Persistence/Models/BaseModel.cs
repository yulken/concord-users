using System.ComponentModel.DataAnnotations.Schema;

namespace concord_users.Src.Infra.Data.Models
{
    public abstract class BaseModel
    {
        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
