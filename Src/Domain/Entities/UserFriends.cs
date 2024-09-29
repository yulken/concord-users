namespace concord_users.Src.Domain.Entities
{
    public class UserFriends
    {
        public UserFriends(User user, List<User> friends) { 
            User = user;    
            Friends = friends;
        }

        public User User { get; set; }
        public List<User> Friends { get; set; } = [];
    }
}
