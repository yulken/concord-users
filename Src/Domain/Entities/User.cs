namespace concord_users.Src.Domain.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string Uuid { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }
        public string ProfilePictureUrl { get; set; }
    }
}
