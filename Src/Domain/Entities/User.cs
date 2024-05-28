using concord_users.Src.Domain.Enums;
using System.Collections.ObjectModel;
using static BCrypt.Net.BCrypt;

namespace concord_users.Src.Domain.Entities
{
    public class User
    {
        private User() { }

        public User(
            string name,
            string email,
            string login,
            string plaintextPassword
            ) 
        {
            ArgumentNullException.ThrowIfNull(name);
            ArgumentNullException.ThrowIfNull(email);
            ArgumentNullException.ThrowIfNull(login);
            ArgumentNullException.ThrowIfNull(plaintextPassword);

            Name = name;
            Email = email;
            Login = login;
            Uuid = Guid.NewGuid();
            Status = UserStatus.Active;
            Password = HashPassword(plaintextPassword);
        }

        public User(
            string uuid,
            string name,
            string email,
            string login,
            string encryptedPassword,
            string status,
            string profilePictureUrl
            )
        {
            ArgumentNullException.ThrowIfNull(uuid);
            ArgumentNullException.ThrowIfNull(name);
            ArgumentNullException.ThrowIfNull(email);
            ArgumentNullException.ThrowIfNull(login);
            ArgumentNullException.ThrowIfNull(encryptedPassword);
            ArgumentNullException.ThrowIfNull(status);

            Name = name;
            Email = email;
            Login = login;
            Uuid = Guid.Parse(uuid);
            Status = UserStatusUtil.ShortStringToEnum(status);
            Password = encryptedPassword;
            ProfilePictureUrl = profilePictureUrl;
        }

        public Guid Uuid { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password;
        public string Login { get; set; }
        public UserStatus Status { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public DateTime? DeletedAt { get; set; }

        public void Activate()
        {
            this.Status = UserStatus.Active;

        }

        public void Deactivate()
        {
            this.Status = UserStatus.Deleted;
            this.DeletedAt = DateTime.UtcNow;
        }

        public bool IsSelf(Guid uuid)
        {
            return Uuid == uuid;
        }

        public bool IsPasswordCorrect(string plaintextPassword)
        {
            return Verify(plaintextPassword, Password);
        }
    }
}
