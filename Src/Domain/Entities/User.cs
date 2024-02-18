using concord_users.Src.Domain.Enums;

namespace concord_users.Src.Domain.Entities
{
    public class User
    {
        public long? Id { get; set; }
        public Guid Uuid { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Login { get; set; }
        public UserStatus Status { get; set; }
        public string? ProfilePictureUrl { get; set; }

        public void Activate()
        {
            this.Status = UserStatus.Active;

        }

        public void Deactivate()
        {
            this.Status = UserStatus.Deleted;
        }
    }
}
