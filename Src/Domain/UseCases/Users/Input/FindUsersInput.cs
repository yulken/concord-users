namespace concord_users.Src.Domain.UseCases.Users.Input
{
    public class FindUsersInput
    {
        public string? Uuid { get; set; }
        public string? Login { get; set; }
        public string? Email { get; set; }
        public string? ExceptUuid { get; set; }

    }
}
