namespace concord_users.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Uuid { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }
        public string ProfilePictureUrl { get; set; }
    }
}
